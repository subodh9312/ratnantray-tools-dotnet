using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Footsteps.Controller.Utilities;

namespace Footsteps.Account
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "Footsteps Infotech Inc. - Change Password";
            MetaDescription = "Footsteps Infotech Inc. Change Password to keep your profile up to date.";
            MetaKeywords = "Footsteps Infotech Inc. Change Password, Administer Profile Footsteps Infotech Inc.";
            Literal literal = Page.Master.FindControl("TitleLiteral") as Literal;
            if (literal != null)
                literal.Text = "Footsteps Infotech Inc. - Change Password";
            literal = Page.Master.FindControl("SubLineLiteral") as Literal;
            if (literal != null)
                literal.Text = "Use the form below to change your password.";
            ChangeUserPassword.MailDefinition.From = MailUtility.SiteAdminstratorMail;
        }

        protected void ChangeUserPassword_SendingMail(object sender, MailMessageEventArgs e)
        {
            MailUtility.GetSmtpSettings().Send(e.Message);
            e.Cancel = true;
        }
    }
}
