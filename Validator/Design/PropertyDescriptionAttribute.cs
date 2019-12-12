using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

using Ratnantray.Properties;

namespace Ratnantray.Design
{
    [AttributeUsage(AttributeTargets.All)]
    internal sealed class PropertyDescriptionAttribute:DescriptionAttribute
    {
        public PropertyDescriptionAttribute(string descriptionKey)
            : base(Resources.ResourceManager.GetString(descriptionKey))
        {

        }
    }
}
