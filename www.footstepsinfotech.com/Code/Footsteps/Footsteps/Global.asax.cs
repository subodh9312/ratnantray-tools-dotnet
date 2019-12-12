using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.DynamicData;
using System.Web.Routing;
using DynamicDataExtensions.Attributes;
using DynamicDataExtensions.Attributes.ExtensionMethods;
using DynamicDataExtensions.Controls;
using DynamicDataExtensions.Routing;
using Microsoft.Web.DynamicData.ModelProviders;
using Footsteps.Controller;

namespace Footsteps
{
    public class Global : System.Web.HttpApplication
    {
        private static readonly MetaModel s_defaultModel = new CustomMetaModel(GetVisibleColumns);
        public static MetaModel DefaultModel
        {
            get
            {
                return s_defaultModel;
            }
        }

        #region Visible Columns Generator
        public static IEnumerable<MetaColumn> GetVisibleColumns(IEnumerable<MetaColumn> columns)
        {
            var visibleColumns = from c in columns
                                 where IsHidden(c)
                                 select c;
            return visibleColumns;
        }

        public static bool IsHidden(MetaColumn column)
        {
            var page = (System.Web.UI.Page)System.Web.HttpContext.Current.CurrentHandler;
            var pageTemplate = page.GetPageTemplate();

            var hideIn = column.GetAttribute<HideColumnInAttribute>();
            if (hideIn != null)
                return !((hideIn.PageTemplate & pageTemplate) == pageTemplate);

            return true;
        }
        #endregion

        public static void RegisterRoutes(RouteCollection routes)
        {
            //                    IMPORTANT: DATA MODEL REGISTRATION 
            // Uncomment this line to register a Domain Service for ASP.NET Dynamic Data.
            // Set ScaffoldAllTables = true only if you are sure that you want all tables in the
            // data model to support a scaffold (i.e. templates) view. To control scaffolding for
            // individual tables, create a partial class for the table and apply the
            // [ScaffoldTable(true)] attribute to the partial class.
            // Note: Make sure that you change "YourDomainServiceType" to the name of the data context
            // class in your application.
            DefaultModel.RegisterContext(new DomainModelProvider(typeof(Biz)), new ContextConfiguration() { ScaffoldAllTables = true });
            DefaultModel.EntityTemplateFactory = new AdvancedEntityTemplateFactory();

            // The following statement supports separate-page mode, where the List, Detail, Insert, and 
            // Update tasks are performed by using separate pages. To enable this mode, uncomment the following 
            // route definition, and comment out the route definitions in the combined-page mode section that follows.
            routes.Add(new DynamicDataRoute("{table}/{action}.aspx")
            {
                Constraints = new RouteValueDictionary(new { action = "List|Details|Edit|Insert|RSS" }),
                Model = DefaultModel
            });

            // The following statements support combined-page mode, where the List, Detail, Insert, and
            // Update tasks are performed by using the same page. To enable this mode, uncomment the
            // following routes and comment out the route definition in the separate-page mode section above.
            //routes.Add(new DynamicDataRoute("{table}/ListDetails.aspx") {
            //    Action = PageAction.List,
            //    ViewName = "ListDetails",
            //    Model = DefaultModel
            //});

            //routes.Add(new DynamicDataRoute("{table}/ListDetails.aspx") {
            //    Action = PageAction.Details,
            //    ViewName = "ListDetails",
            //    Model = DefaultModel
            //});
        }

        void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);
        }

    }
}
