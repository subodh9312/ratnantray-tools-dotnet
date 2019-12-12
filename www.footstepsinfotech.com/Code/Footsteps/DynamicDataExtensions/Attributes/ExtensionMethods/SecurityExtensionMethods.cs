using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.DynamicData;
using System.Web.Security;
using DynamicDataExtensions.Attributes.Enums;
using DynamicDataExtensions.Attributes;

namespace DynamicDataExtensions.Attributes.ExtensionMethods
{
    /// <summary>
    /// Permissions Attributes Helper Extension Methods
    /// </summary>
    public static class SecurityExtensionMethods
    {
        /// <summary>
        /// Secures the column visible.
        /// </summary>
        /// <param name="column">The column.</param>
        /// <returns></returns>
        public static Boolean ColumnIsVisible(this MetaColumn column)
        {
            var userRoles = Roles.GetRolesForUser();
            var activeColumnActions = column.GetColumnPermissions(userRoles);
            if (activeColumnActions.Contains(ColumnActions.DenyRead))
                return false;
            else
                return true;
        }

        /// <summary>
        /// Secures the column read only.
        /// </summary>
        /// <param name="column">The column.</param>
        /// <returns></returns>
        public static Boolean IsSecureColumnReadOnly(this MetaColumn column)
        {
            var userRoles = Roles.GetRolesForUser();
            var activeColumnActions = column.GetColumnPermissions(userRoles);
            if (activeColumnActions.Contains(ColumnActions.DenyWrite))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Get a list of permissions for the specified role
        /// </summary>
        /// <param name="attributes">
        /// Is a AttributeCollection taken 
        /// from the column of a MetaTable
        /// </param>
        /// <param name="role">
        /// name of the role to be matched with
        /// </param>
        /// <returns>A List of permissions</returns>
        public static List<ColumnActions> GetColumnPermissions(this MetaColumn column, String[] roles)
        {
            var permissions = new List<ColumnActions>();

            // you could put: 
            // var attributes = column.Attributes;
            // but to make it clear what type we are using:
            System.ComponentModel.AttributeCollection attributes = column.Attributes;

            // check to see if any roles passed
            if (roles.Count() > 0)
            {
                // using Linq to Object to get 
                // the permissions for each role
                permissions = (from a in attributes.OfType<SecureColumnAttribute>()
                               where a.HasAnyRole(roles)
                               select a.Actions).ToList();
            }
            return permissions;
        }

        /// <summary>
        /// Returns a copy of the array of string 
        /// all in lowercase
        /// </summary>
        /// <param name="strings">Array of strings</param>
        /// <returns>array of string all in lowercase</returns>
        public static String[] AllToLower(this String[] strings)
        {
            String[] temp = new String[strings.Count()];
            for (int i = 0; i < strings.Count(); i++)
            {
                temp[i] = strings[i].ToLower();
            }
            return temp;
        }

        /// <summary>
        /// helper method to check for roles in this attribute
        /// the comparison is case insensitive
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        public static Boolean HasAnyRole(this SecureTableAttribute tablePermission, String[] roles)
        {
            var tpsRoles = tablePermission.Roles.AllToLower();
            // call extension method to convert array to lower case for compare
            foreach (var role in roles)
            {
                if (tpsRoles.Contains(role.ToLower()))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// helper method to check for roles in this attribute
        /// the comparison is case insensitive
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        public static Boolean HasAnyRole(this SecureColumnAttribute columnPermission, String[] roles)
        {
            var cpsRoles = columnPermission.Roles.AllToLower();
            // call extension method to convert array to lower case for compare
            foreach (var role in roles)
            {
                if (cpsRoles.Contains(role.ToLower()))
                    return true;
            }
            return false;
        }
    }
}

///// <summary>
///// Get a list of permissions for the specified role
///// </summary>
///// <param name="attributes">
///// Is a AttributeCollection taken from the column of a MetaTable
///// </param>
///// <param name="role">name of the role to be matched with</param>
///// <returns>A List of permissions</returns>
//public static List<TableActions> GetTablePermissions(this MetaTable table, String[] roles)
//{
//    var permissions = new List<TableActions>();
//    var attributes = table.Attributes;

//    // check to see if any roles passed
//    if (roles.Count() > 0)
//    {
//        // using Linq to Object to get 
//        // the permissions foreach role
//        permissions = (from a in attributes.OfType<SecureTableAttribute>()
//                       where a.HasAnyRole(roles)
//                       select a.Permission).ToList();
//    }
//    return permissions;
//}

///// <summary>
///// Get a list of permissions for the specified role
///// </summary>
///// <param name="attributes">
///// Is a AttributeCollection taken from the column of a MetaTable
///// </param>
///// <param name="role">name of the role to be matched with</param>
///// <returns>A List of permissions</returns>
//public static List<TableActions> GetFkTablePermissions(this MetaColumn column, String[] roles)
//{
//    var permissions = new List<TableActions>();
//    var foreignKeyColumn = column as MetaForeignKeyColumn;
//    var attributes = foreignKeyColumn.ParentTable.Attributes;

//    // check to see if any roles passed
//    if (roles.Count() > 0)
//    {
//        // using Linq to Object to get 
//        // the permissions foreach role
//        permissions = (from a in attributes.OfType<SecureTableAttribute>()
//                       where a.HasAnyRole(roles)
//                       select a.Permission).ToList();
//    }
//    return permissions;
//}

///// <summary>
///// Get a list of permissions for the specified role
///// </summary>
///// <param name="attributes">
///// Is a AttributeCollection taken from the column of a MetaTable
///// </param>
///// <param name="role">name of the role to be matched with</param>
///// <returns>A List of permissions</returns>
//public static List<TableActions> GetChildrenTablePermissions(this MetaColumn column, String[] roles)
//{
//    var permissions = new List<TableActions>();
//    var childrenColumn = column as MetaChildrenColumn;
//    var attributes = childrenColumn.Attributes;

//    // check to see if any roles passed
//    if (roles.Count() > 0)
//    {
//        // using Linq to Object to get 
//        // the permissions for each role
//        permissions = (from a in attributes.OfType<SecureTableAttribute>()
//                       where a.HasAnyRole(roles)
//                       select a.Permission).ToList();
//    }
//    return permissions;
//}
