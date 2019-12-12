using System;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using mytemplate.Controller.Utilities;

namespace mytemplate.Account
{
    public partial class UnlockUserAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Request.QueryString["ID"]) || !Regex.IsMatch(Request.QueryString["ID"], @"[0-9a-f]{8}\-([0-9a-f]{4}\-){3}[0-9a-f]{12}"))
                InformationLabel.Text = "Invalid ID was requested to be verified.";
            else
            {
                Guid UserId = new Guid(Request.QueryString["ID"]);

                MembershipUser UserInfo = Membership.GetUser(UserId);

                if (UserInfo == null)
                    InformationLabel.Text = "The user account could not be found in the membership database.";
                else
                {
                    if (UserInfo.IsLockedOut)
                    {
                        UserInfo.UnlockUser();
                        Membership.UpdateUser(UserInfo);
                        InformationLabel.Text = "Your account has been unlocked and you can now log into the site.";
                        SendAccountUnlockMail();
                    }
                    else
                        InformationLabel.Text = "Your account has already been unlocked and you can now log into the site.";
                }
            }

            Title = "My Template - Unlock User";
            MetaDescription = "My Template Unlock User to be able to access your account.";
            MetaKeywords = "My Template Unlock User, Unlock User @ mytemplate.com";
            Literal literal = Page.Master.FindControl("TitleLiteral") as Literal;
            if (literal != null)
                literal.Text = "My Template - Unlock User";
            literal = Page.Master.FindControl("SubLineLiteral") as Literal;
            if (literal != null)
                literal.Text = "Unlock User Account.";
        }

        private void SendAccountUnlockMail()
        {
            try
            {
                Guid UserId = new Guid(Request.QueryString["ID"]);

                MembershipUser UserInfo = Membership.GetUser(UserId);

                MailMessage Message = new MailMessage(MailUtility.SiteAdminstratorMail, UserInfo.Email);

                Message.Subject = "My Template: Your account has been unlocked successfully...";
                Message.Priority = MailPriority.High;
                Message.IsBodyHtml = true;
                Message.Body = MailUtility.ReadFile(Request.Url.GetLeftPart(UriPartial.Authority) + Page.ResolveUrl("~/DynamicData/Content/EmailTemplates/AccountUnlockNotification.htm"));

                Message.Body = Message.Body.Replace("<%UserName%>", UserInfo.UserName);

                MailUtility.GetSmtpSettings().Send(Message);
            }
            catch
            {
            }
        }
    }
}