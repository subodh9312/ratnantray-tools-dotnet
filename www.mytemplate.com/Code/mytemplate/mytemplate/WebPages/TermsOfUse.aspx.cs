using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mytemplate.WebPages
{
    public partial class TermsOfUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "Terms of use - My Template.com";
            MetaDescription = "my template terms of use and agreement.";
            MetaKeywords = "My Template terms of use, My Template Acceptance of terms," +
                " My Template Advice, My Template Changes to website, My Template " +
                "Links to third party websites, My Template Copyright, My Template Serverance.";
        }
    }
}