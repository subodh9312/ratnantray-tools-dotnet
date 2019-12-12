using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.DynamicData;
using DynamicDataExtensions.Attributes.Enums;
using DynamicDataExtensions.Attributes.ExtensionMethods;

namespace DynamicDataExtensions.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class SecureTableAttribute : System.Attribute
    {
        // this property is required to work with "AllowMultiple = true" ref David Ebbo
        // As implemented, this identifier is merely the Type of the attribute. However, 
        // it is intended that the unique identifier be used to identify two 
        // attributes of the same type.
        public override object TypeId { get { return this; } }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="actions"></param>
        /// <param name="roles"></param>
        public SecureTableAttribute(TableActions actions, params String[] roles)
        {
            this._actions = actions;
            this._roles = roles;
        }

        private String[] _roles;
        public String[] Roles
        {
            get { return this._roles; }
            set { this._roles = value; }
        }

        private TableActions _actions;
        public TableActions Actions
        {
            get { return this._actions; }
            set { this._actions = value; }
        }

        /// <summary>
        /// helper method to check for roles in this attribute
        /// the comparison is case insensitive
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public Boolean HasRole(String role)
        {
            // call extension method to convert array to lower case for compare
            String[] rolesLower = _roles.AllToLower();
            return rolesLower.Contains(role.ToLower());
        }
    }
}