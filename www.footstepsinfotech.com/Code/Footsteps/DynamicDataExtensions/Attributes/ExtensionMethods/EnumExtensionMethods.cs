using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Web.DynamicData;
using System.Web.UI.WebControls;
using System.Collections;

namespace DynamicDataExtensions.Attributes.ExtensionMethods
{
    public static class EnumExtensionMethods
    {
        public static T ToEnum<T>(this String enumString) //where T : Enum
        {
            var value = Enum.Parse(typeof(T), enumString);
            return (T)value;
        }

        public static T ToEnum<T>(this int enumInt) //where T : Enum
        {
            var value = Enum.Parse(typeof(T), enumInt.ToString());
            return (T)value;
        }

        public static String ToString<T>(this int enumInt) //where T : Enum
        {
            var value = Enum.Parse(typeof(T), enumInt.ToString()).ToString();
            return value;
        }
    }
}
