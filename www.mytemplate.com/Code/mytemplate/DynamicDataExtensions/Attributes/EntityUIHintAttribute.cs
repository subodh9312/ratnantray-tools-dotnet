using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Resources;
using System.Globalization;
using System.Linq;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Web;

namespace DynamicDataExtensions.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class EntityUIHintAttribute : Attribute
    {
        private IDictionary<String, Object> _controlParameters;

        public IDictionary<String, Object> ControlParameters
        {
            get { return this._controlParameters; }
        }

        /// <summary>
        /// Gets or sets the UI hint.
        /// </summary>
        /// <value>The UI hint.</value>
        public String UIHint { get; private set; }

        public EntityUIHintAttribute(String uiHint) : this(uiHint, new Object[0]) { }

        public EntityUIHintAttribute(String uiHint, params Object[] controlParameters)
        {
            UIHint = uiHint;
            _controlParameters = BuildControlParametersDictionary(controlParameters);
        }

        public override Object TypeId
        {
            get { return this; }
        }

        private IDictionary<String, Object> BuildControlParametersDictionary(Object[] objArray)
        {
            IDictionary<String, Object> dictionary = new Dictionary<String, Object>();
            if ((objArray != null) && (objArray.Length != 0))
            {
                if ((objArray.Length % 2) != 0)
                    throw new InvalidOperationException("Need even number of control parameters.");

                for (int i = 0; i < objArray.Length; i += 2)
                {
                    Object keyObject = objArray[i];
                    Object valueObject = objArray[i + 1];
                    if (keyObject == null)
                        throw new InvalidOperationException(String.Format("{0} control parameter key is null.", i));

                    String keyString = keyObject as String;
                    if (keyString == null)
                        throw new InvalidOperationException(String.Format("{0} control parameter key is not a String.", keyObject.ToString()));

                    if (dictionary.ContainsKey(keyString))
                        throw new InvalidOperationException(String.Format("{0} control parameter key occurs more than once.", keyString));

                    dictionary[keyString] = valueObject;
                }
            }
            return dictionary;
        }
    }
}
