using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.DynamicData;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace DynamicDataExtensions.Attributes
{
    /*******************************************/
    //RESTRICTIONS:
    //1. Column Display Names cannot have '/' or '-' character.
    /*******************************************/
    public class DecimalAttribute : Attribute
    {
        public string Postfix { get; private set; }

        private DecimalAttribute()
        {
        }

        public DecimalAttribute(string postfix)
        {
            Postfix = postfix;
        }
    }
}
