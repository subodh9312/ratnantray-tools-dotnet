using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Footsteps
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            Title = "Home - Footsteps Infotech Inc.";
            MetaKeywords = "Footsteps Infotech, Software Company Pune, Software Company Dhule, Dhule Software Company, Pune Software Company";
            MetaDescription = "We are a Software development and Consultancy Firm based out in Pune and Dhule.";
            MetaDescription += " With major clients and a strong reputation, we believe in building our a best possible solution for your business.";
        }
    }
}