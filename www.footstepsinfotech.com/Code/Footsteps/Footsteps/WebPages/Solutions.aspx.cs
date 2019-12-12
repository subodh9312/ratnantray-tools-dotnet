using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Footsteps
{
    public partial class Solutions : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            Title = "Solutions - Footsteps Infotech Inc.";
            MetaKeywords = "Why Choose Us, Clients Say, Customer Profiles,";
            MetaDescription = "Our proven success is built upon mutual respect";
            MetaDescription += " and a Team Spirit Approach that lets us consistently";
            MetaDescription += "accomplish what we promise and exceed our customer’s expectations..";
        }
    }
}