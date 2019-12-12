using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Web;
using System.Web.DynamicData;

using DynamicDataExtensions.Attributes.Enums;

namespace DynamicDataExtensions.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class HideColumnInAttribute : Attribute
    {
        public PageTemplate PageTemplate { get; private set; }

        public HideColumnInAttribute() { }

        public HideColumnInAttribute(PageTemplate lookupTable)
        {
            PageTemplate = lookupTable;
        }
    }
}
