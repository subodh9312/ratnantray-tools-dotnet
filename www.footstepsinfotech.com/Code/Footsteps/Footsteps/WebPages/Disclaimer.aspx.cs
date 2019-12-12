using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Footsteps.WebPages
{
    public partial class Disclaimer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "Footsteps.com Disclaimer";
            MetaDescription = "Footsteps Infotech Inc. disclaimer, Footsteps.com limitation of liability" +
                ",  Footsteps.com Indemnity and Content";
            MetaKeywords = "Footsteps Infotech Inc. disclaimer, Footsteps Infotech Inc. Disclaimer and limitation of liability," +
                " Footsteps Infotech Inc. Indemnity, Footsteps Infotech Inc. Content";
        }
    }
}