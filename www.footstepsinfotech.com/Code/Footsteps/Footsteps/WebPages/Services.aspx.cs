using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Footsteps
{
    public partial class Services : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            Title = "Services Offered - Footsteps Infotech Inc.";
            MetaKeywords = "Services Offered, Services At Footsteps Infotech Inc., SEO, SMO, Web Hosting, Mobile Development, Windows Development, Open Source platforms";
            MetaDescription = "Providing services like Global Solutions, Consultancy Services, Web Hosting Services, Mobile Development,";
            MetaDescription += "Windows Development, Designing Services, Search Engine Optimisation. etc.";
        }
    }
}