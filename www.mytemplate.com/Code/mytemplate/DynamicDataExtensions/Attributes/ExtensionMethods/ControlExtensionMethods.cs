using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Web.UI;
using DynamicDataExtensions.Attributes.Enums;

namespace DynamicDataExtensions.Attributes.ExtensionMethods
{
    public static class ControlExtensionMethods
    {
        // "~/DynamicData/PageTemplates/List.aspx"
        private const String extension = ".aspx";

        /// <summary>
        /// Gets the page template from the page.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        public static PageTemplate GetPageTemplate(this Page page)
        {
            try
            {
                return (PageTemplate)Enum.Parse(typeof(PageTemplate),
                    page.RouteData.Values["action"].ToString());
            }
            catch (ArgumentException)
            {
                return PageTemplate.Unknown;
            }
        }
    }
}
