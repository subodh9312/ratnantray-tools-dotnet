using System;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Footsteps.Account
{
    public partial class ChangePasswordSuccess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "Footsteps Infotech Inc. - Change Password Confirmation";
            MetaDescription = "Footsteps Infotech Inc. Change Password to keep your profile up to date.";
            MetaKeywords = "Footsteps Infotech Inc. Change Password, Administer Profile Footsteps Infotech Inc.";
            Literal literal = Page.Master.FindControl("TitleLiteral") as Literal;
            if (literal != null)
                literal.Text = "Footsteps Infotech Inc. - Change Password Confirmation";
            literal = Page.Master.FindControl("SubLineLiteral") as Literal;
            if (literal != null)
                literal.Text = "Your password has been reset Successfully!";

            FormsAuthentication.SignOut();
        }
    }
}
