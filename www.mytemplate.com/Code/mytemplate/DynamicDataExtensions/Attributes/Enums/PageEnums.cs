using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicDataExtensions.Attributes.Enums
{
    [Flags]
    public enum PageTemplate
    {
        // standard page templates
        Details = 0x01,
        Edit = 0x02,
        Insert = 0x04,
        List = 0x08,
        ListDetails = 0x10,
        // custom page templates
        //UpdateableList = 0x12,
        //EventEdit = 0x14,
        Unknown = 0xff,
    }
}
