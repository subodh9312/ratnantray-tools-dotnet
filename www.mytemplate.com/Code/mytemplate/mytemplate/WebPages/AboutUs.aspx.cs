using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mytemplate.WebPages
{
    public partial class AboutUs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HyperLink hyperlink = Page.Master.FindControl("TitleHyperLink") as HyperLink;
            if (hyperlink != null)
            {
                hyperlink.Text = "About Us";
                hyperlink.NavigateUrl = "~/WebPages/AboutUs.aspx";
            }
            Literal literal = Page.Master.FindControl("SubLineLiteral") as Literal;
            if (literal != null)
                literal.Text = "Note from Admin's Desk";

            Title = "About Us - My Template";
            MetaKeywords = "About My Template";
            MetaDescription = "About My Template - Explains what My Template is all about"; 
        }
    }
}