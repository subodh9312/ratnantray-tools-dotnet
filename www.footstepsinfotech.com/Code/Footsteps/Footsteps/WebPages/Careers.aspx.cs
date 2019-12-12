using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Footsteps
{
    public partial class Careers : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            Title = "Careers - Footsteps Infotech Inc.";
            MetaKeywords = "Work With Us, Employee Testimonials, Work Culture, Work Environment,";
            MetaDescription = "An Open culture, Great work environment, and most importantly a sense of belonging ";
            MetaDescription += " towards the Employees has formed a perfect";
            MetaDescription += "combination for my Future Growth..";
        }
    }
}