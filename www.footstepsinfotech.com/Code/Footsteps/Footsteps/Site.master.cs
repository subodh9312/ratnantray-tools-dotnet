using System.ComponentModel.DataAnnotations;
using System.Web.DynamicData;
using System.Web.UI.WebControls;
using System;
using System.Web.UI.HtmlControls;
using System.Web.UI;
using Footsteps.Controller.Library;

namespace Footsteps
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            string url = Request.Url.ToString();
            HtmlGenericControl navMenu = FindControl("menu") as HtmlGenericControl;
            if (navMenu != null)
            {
                // find its inner control
                foreach (Control control in navMenu.Controls)
                {
                    HtmlGenericControl listItem = control as HtmlGenericControl;
                    if (listItem != null)
                    {
                        string originalAttribute = listItem.Attributes["class"];
                        if (url.ToLower().IndexOf(listItem.ID.ToLower()) != -1)
                        {
                            if (!String.IsNullOrEmpty(originalAttribute))
                                listItem.Attributes.Add("class", originalAttribute + " active");
                            else
                                listItem.Attributes.Add("class", "active");
                            break;
                        }
                    }
                }
            }

            // CssLink.Attributes.Add("rel", "stylesheet");
            // CssLink.Attributes.Add("href", Constants.CookieLessDomain + "/Styles/css/Compressed.css");
            // CssLink.Attributes.Add("type", "text/css");
            // CssLink.Attributes.Add("media", "screen");

            CachingBiz cachingBiz = new CachingBiz();
            JavascriptLiteral.Text = cachingBiz.GetJqueryContents(Server.MapPath(@"/Scripts/js/Combined.js"));
            CssLiteral.Text = cachingBiz.GetCompressedSiteCss(Server.MapPath(@"/Styles/css/Site.css"));
        }
    }
}
