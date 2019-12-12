using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Footsteps.WebPages
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

            Title = "About Us - Footsteps Infotech Inc.";
            MetaKeywords = "About Footsteps Infotech Inc., Software Development, Products Offered, Life at Footsteps Infotech Inc.";
            MetaDescription = "About Footsteps Infotech Inc. - Explains what Footsteps Infotech Inc. is all about"; 
        }
    }
}