using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Text.RegularExpressions;
using System.Web.Security;
using System.Net.Mail;
using Footsteps.Controller.Utilities;

namespace Footsteps.Account
{
    public partial class VerifyUserAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Request.QueryString["ID"]) || !Regex.IsMatch(Request.QueryString["ID"], @"[0-9a-f]{8}\-([0-9a-f]{4}\-){3}[0-9a-f]{12}"))
            {
                InformationLabel.Text = "Invalid ID was requested to be verified.";
            }
            else
            {
                Guid UserId = new Guid(Request.QueryString["ID"]);

                MembershipUser UserInfo = Membership.GetUser(UserId);

                if (UserInfo == null)
                {
                    InformationLabel.Text = "The user account could not be found in the membership database.";
                }
                else
                {
                    if (UserInfo.IsApproved)
                    {
                        InformationLabel.Text = "Your account has already been verified and you can now log into the site.";
                        InformationLabel.Text += "You will now be redirect to the Login Page.";
                    }
                    else
                    {
                        UserInfo.IsApproved = true;
                        Membership.UpdateUser(UserInfo);
                        InformationLabel.Text = "Your account has been verified and you can now log into the site.";
                        InformationLabel.Text += "You will now be redirect to the Login Page.";
                        SendAccountActivationMail();
                    }
                }
            }

            Title = "Footsteps Infotech Inc. - Verfy User Account";
            MetaDescription = "Footsteps Infotech Inc. Verify Account to activate your profile.";
            MetaKeywords = "Footsteps Infotech Inc. Verify Account, Footsteps Infotech Inc. Verify User Account";
            Literal literal = Page.Master.FindControl("TitleLiteral") as Literal;
            if (literal != null)
                literal.Text = "Footsteps Infotech Inc. - Verify User Account";
            literal = Page.Master.FindControl("SubLineLiteral") as Literal;
            if (literal != null)
                literal.Text = "Account Verification!";
        }

        private void SendAccountActivationMail()
        {
            try
            {
                Guid UserId = new Guid(Request.QueryString["ID"]);

                MembershipUser UserInfo = Membership.GetUser(UserId);

                MailMessage Message = new MailMessage(MailUtility.SiteAdminstratorMail, UserInfo.Email);

                Message.Subject = "Footsteps Infotech Inc.: Your account has been activated successfully...";
                Message.Priority = MailPriority.High;
                Message.IsBodyHtml = true;
                Message.Body = MailUtility.ReadFile(Request.Url.GetLeftPart(UriPartial.Authority) + Page.ResolveUrl("~/DynamicData/Content/EmailTemplates/AccountActivationNotification.htm"));

                Message.Body = Message.Body.Replace("<%UserName%>", UserInfo.UserName);

                MailUtility.GetSmtpSettings().Send(Message);
            }
            catch
            {

            }
        }
    }
}