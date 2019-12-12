using System;
using System.Net.Mail;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Footsteps.Controller.Utilities;

namespace Footsteps.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            ForgotPassword.NavigateUrl = "RecoverPassword.aspx";

            Title = "Footsteps Infotech Inc. - Login";
            MetaDescription = "Footsteps Infotech Inc. login to access your account.";
            MetaKeywords = "Footsteps Infotech Inc. login, Login into Administer Profile Footsteps Infotech Inc.";
            Literal literal = Page.Master.FindControl("TitleLiteral") as Literal;
            if (literal != null)
                literal.Text = "Footsteps Infotech Inc. - Login";
            literal = Page.Master.FindControl("SubLineLiteral") as Literal;
            if (literal != null)
                literal.Text = "Use the form below to login into your account.";
        }

        protected void LoginUser_LoggedIn(object sender, EventArgs e)
        {
            Response.Redirect("~/Account/ManageProfile.aspx");
        }

        protected void LoginUser_LoginError(object sender, EventArgs e)
        {
            //Check if user exists in database.
            MembershipUser UserInfo = Membership.GetUser(LoginUser.UserName);

            if (UserInfo != null)
            {
                if (UserInfo.IsLockedOut)
                {
                    CompleteLoginMessage.Text = "Your account has been locked out because of a maximum number of incorrect login attempts." + 
                        " You will NOT be able to login until you unlock your account.";
                    SendMail.Text = "CLICK HERE to recieve account Unlock mail.";
                    SendMail.Visible = true;
                }
                else if (!UserInfo.IsApproved)
                {
                    CompleteLoginMessage.Text = "Your account has not yet been activated yet. Please check your mailbox (Inbox and Spam folders)" +
                        " for the account activation mail.";
                    SendMail.Text = "CLICK HERE to recieve another account activation mail.";
                    SendMail.Visible = true;
                }
            }
        }

        protected void SendMail_Click(object sender, EventArgs e)
        {
            MembershipUser UserInfo = Membership.GetUser(LoginUser.UserName);

            if (SendMail.Text == "CLICK HERE to recieve account Unlock mail.")
            {
                try
                {
                    using (MailMessage Message = new MailMessage(MailUtility.SiteAdminstratorMail, UserInfo.Email))
                    {
                        Message.Subject = "Footsteps Infotech Inc.: Steps to unlock your account...";
                        Message.Priority = MailPriority.High;
                        Message.IsBodyHtml = true;
                        Message.Body = MailUtility.ReadFile(Request.Url.GetLeftPart(UriPartial.Authority) + Page.ResolveUrl("~/DynamicData/Content/EmailTemplates/AccountUnlock.htm"));

                        string UnlockURL = Request.Url.GetLeftPart(UriPartial.Authority) + Page.ResolveUrl("~/Account/UnlockUserAccount.aspx?ID=" + UserInfo.ProviderUserKey.ToString());

                        Message.Body = Message.Body.Replace("<%UnlockUrl%>", UnlockURL);
                        Message.Body = Message.Body.Replace("<%UserName%>", UserInfo.UserName);

                        MailUtility.GetSmtpSettings().Send(Message);

                        CompleteLoginMessage.Text = "Account Unlock mail was sent to " + UserInfo.Email + ". Plesae check your mailbox (inbox and spam) to unlock your account.";
                        SendMail.Text = "";
                        SendMail.Visible = false;
                    }
                }
                catch
                {
                    CompleteLoginMessage.Text = "Failure sending account unlock mail to " + UserInfo.Email + ". Please retry after sometime. If problem persists please contact contact " + MailUtility.SiteAdminstratorMail;
                    SendMail.Text = "";
                    SendMail.Visible = false;
                }

            }
            else if (SendMail.Text == "CLICK HERE to recieve another account activation mail.")
            {
                try
                {
                    MailMessage Message = new MailMessage(MailUtility.SiteAdminstratorMail, UserInfo.Email);

                    Message.Subject = "Footsteps Infotech Inc.: Steps to activate your account...";
                    Message.Priority = MailPriority.High;
                    Message.IsBodyHtml = true;
                    Message.Body = MailUtility.ReadFile(Request.Url.GetLeftPart(UriPartial.Authority) + Page.ResolveUrl("~/DynamicData/Content/EmailTemplates/AccountActivation.htm"));

                    string VerifyURL = Request.Url.GetLeftPart(UriPartial.Authority) + Page.ResolveUrl("~/Account/VerifyUserAccount.aspx?ID=" + UserInfo.ProviderUserKey.ToString());

                    Message.Body = Message.Body.Replace("<%VerifyUrl%>", VerifyURL);
                    Message.Body = Message.Body.Replace("<%UserName%>", UserInfo.UserName);

                    MailUtility.GetSmtpSettings().Send(Message);
                    CompleteLoginMessage.Text = "Account activation mail was sent to " + UserInfo.Email + ". Plesae check your mailbox (inbox and spam) to activate your account.";
                    SendMail.Text = "";
                    SendMail.Visible = false;
                }
                catch
                {
                    CompleteLoginMessage.Text = "Failure sending account unlock mail to " + "";
                    SendMail.Text = "";
                    SendMail.Visible = false;
                }
            }
        }
    }
}
