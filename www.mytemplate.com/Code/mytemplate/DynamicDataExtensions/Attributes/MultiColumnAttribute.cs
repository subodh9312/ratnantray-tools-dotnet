using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DynamicDataExtensions.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MultiColumnAttribute : Attribute
    {
        /// <summary>
        /// Gets or sets the column span.
        /// </summary>
        /// <value>The column span.</value>
        public int ColumnSpan { get; private set; }

        // Default instantiation, used for DefaultIfEmpty 
        public static MultiColumnAttribute Default = new MultiColumnAttribute();

        // default constructor.
        public MultiColumnAttribute() 
        { 
            // set default to 1
            ColumnSpan = 1;
        }

        // regular constructor
        public MultiColumnAttribute(int columnSpan)
        {
            // never let columns be set to zero
            if (columnSpan == 0)
                ColumnSpan = 1;
            else
                ColumnSpan = columnSpan;
        }
    }
}