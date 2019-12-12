using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mytemplate.Account
{
    public partial class ChangePasswordSuccess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "My Template - Change Password Confirmation";
            MetaDescription = "My Template Change Password to keep your profile up to date.";
            MetaKeywords = "My Template Change Password, Administer Profile My Template";
            Literal literal = Page.Master.FindControl("TitleLiteral") as Literal;
            if (literal != null)
                literal.Text = "My Template - Change Password Confirmation";
            literal = Page.Master.FindControl("SubLineLiteral") as Literal;
            if (literal != null)
                literal.Text = "Your password has been reset Successfully!";
        }
    }
}
