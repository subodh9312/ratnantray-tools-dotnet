using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Footsteps.Controller.Utilities;

namespace Footsteps.Account
{
    public partial class RecoverPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "Footsteps Infotech Inc. - Recover Password";
            MetaDescription = "Footsteps Infotech Inc. Recover Password to reset your profile and login.";
            MetaKeywords = "Footsteps Infotech Inc. Recover Password, Reset Profile Footsteps Infotech Inc.";
            Literal literal = Page.Master.FindControl("TitleLiteral") as Literal;
            if (literal != null)
                literal.Text = "Footsteps Infotech Inc. - Recover Password";
            literal = Page.Master.FindControl("SubLineLiteral") as Literal;
            if (literal != null)
                literal.Text = "Use the form below to Recover your password.";

            PasswordRecovery1.MailDefinition.From = MailUtility.SiteAdminstratorMail;
            PasswordRecovery1.MailDefinition.Subject = "Footsteps Infotech Inc. : Password recovery notification...";
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