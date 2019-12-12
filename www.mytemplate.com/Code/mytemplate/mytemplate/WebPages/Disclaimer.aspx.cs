using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mytemplate.WebPages
{
    public partial class Disclaimer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "mytemplate.com Disclaimer";
            MetaDescription = "My Template disclaimer, mytemplate.com limitation of liability" +
                ",  mytemplate.com Indemnity and Content";
            MetaKeywords = "my template disclaimer, my template Disclaimer and limitation of liability," +
                " my template Indemnity, my template Content";
        }
    }
}