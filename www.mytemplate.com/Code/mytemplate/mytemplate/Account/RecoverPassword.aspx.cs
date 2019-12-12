using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using mytemplate.Controller.Utilities;

namespace mytemplate.Account
{
    public partial class RecoverPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "My Template - Recover Password";
            MetaDescription = "My Template Recover Password to reset your profile and login.";
            MetaKeywords = "My Template Recover Password, Reset Profile My Template";
            Literal literal = Page.Master.FindControl("TitleLiteral") as Literal;
            if (literal != null)
                literal.Text = "My Template - Recover Password";
            literal = Page.Master.FindControl("SubLineLiteral") as Literal;
            if (literal != null)
                literal.Text = "Use the form below to Recover your password.";

            PasswordRecovery1.MailDefinition.From = MailUtility.SiteAdminstratorMail;
            PasswordRecovery1.MailDefinition.Subject = "My Template : Password recovery notification...";
        }

        // Set the field label background color if the user name is not found.
        protected void PasswordRecovery1_UserLookupError(object sender, System.EventArgs e)
        {

        }

        // Reset the field label background color.
        protected void PasswordRecovery1_Load(object sender, System.EventArgs e)
        {
        }

        protected void PasswordRecovery1_SendingMail(object sender, MailMessageEventArgs e)
        {
            MailUtility.GetSmtpSettings().Send(e.Message);
            e.Cancel = true;
        }
    }
}