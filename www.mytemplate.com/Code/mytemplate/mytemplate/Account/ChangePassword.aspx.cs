using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using mytemplate.Controller.Utilities;

namespace mytemplate.Account
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "My Template - Change Password";
            MetaDescription = "My Template Change Password to keep your profile up to date.";
            MetaKeywords = "My Template Change Password, Administer Profile My Template";
            Literal literal = Page.Master.FindControl("TitleLiteral") as Literal;
            if (literal != null)
                literal.Text = "My Template - Change Password";
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
