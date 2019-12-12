using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.DynamicData;
using DynamicDataExtensions.Attributes;
using DynamicDataExtensions.Attributes.ExtensionMethods;

namespace DynamicDataExtensions.Controls
{
    public class AdvancedEntityTemplateFactory : System.Web.DynamicData.EntityTemplateFactory
    {
        // this is not required, as it causes problems for Insert Mode for other Entities.
        /*public override string BuildEntityTemplateVirtualPath(string templateName, DataBoundControlMode mode)
        {
            string path = base.BuildEntityTemplateVirtualPath(templateName, mode);

            if (File.Exists(HttpContext.Current.Server.MapPath(path)))
                return path;

            return path.Replace("_" + mode.ToString(), "");
        }*/

        public override EntityTemplateUserControl CreateEntityTemplate(MetaTable table, DataBoundControlMode mode, string uiHint)
        {
            var et = table.GetAttribute<EntityUIHintAttribute>();
            if (et != null && !String.IsNullOrEmpty(et.UIHint))
                return base.CreateEntityTemplate(table, mode, et.UIHint);

            return base.CreateEntityTemplate(table, mode, uiHint);
        }

        public override string GetEntityTemplateVirtualPath(MetaTable table, DataBoundControlMode mode, string uiHint)
        {
            var et = table.GetAttribute<EntityUIHintAttribute>();
            if (et != null && !String.IsNullOrEmpty(et.UIHint))
                return base.GetEntityTemplateVirtualPath(table, mode, et.UIHint);

            return base.GetEntityTemplateVirtualPath(table, mode, uiHint);
        }
    }
}
