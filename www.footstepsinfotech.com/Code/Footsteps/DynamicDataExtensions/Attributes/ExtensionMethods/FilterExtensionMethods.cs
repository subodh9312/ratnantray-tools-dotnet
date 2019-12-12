using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.DynamicData;
using System.Web.UI;

namespace DynamicDataExtensions.Attributes.ExtensionMethods
{
    public static class FilterExtensionMethods
    {
        /// <summary>
        /// Adds the filters current value to the session.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="column">The column.</param>
        /// <param name="value">The value.</param>
        public static void AddFilterValueToSession(this Page page, MetaColumn column, Object value)
        {
            Dictionary<String, Object> filterValues;
            var objectName = column.Table.DataContextPropertyName;

            // get correct column name 
            var columnName = column.Name;
            if (column is MetaForeignKeyColumn)
                // columnName = ((MetaForeignKeyColumn)column).ForeignKeyNames.ToCommaSeparatedString();
                columnName = ((MetaForeignKeyColumn)column).ForeignKeyNames.ToString();

            // check to see if we already have a session object
            if (page.Session[objectName] != null)
                filterValues = (Dictionary<String, Object>)page.Session[objectName];
            else
                filterValues = new Dictionary<String, Object>();

            // add new filter value to session object
            if (filterValues.Keys.Contains(columnName))
                filterValues[columnName] = value;
            else
                filterValues.Add(columnName, value);

            // add back to session
            if (page.Session[objectName] != null)
                page.Session[objectName] = filterValues;
            else
                page.Session.Add(objectName, filterValues);
        }

        /// <summary>
        /// Gets the filter values from session.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="table">The table.</param>
        /// <param name="defaultValues">The default values.</param>
        /// <returns>An IDictionary of filter values from the session.</returns>
        public static IDictionary<String, Object> GetFilterValuesFromSession(this Page page,
            MetaTable table,
            IDictionary<String, Object> defaultValues)
        {
            var queryString = new StringBuilder();
            var objectName = table.DataContextPropertyName;
            if (page.Session[objectName] != null)
            {
                var sessionFilterValues = new Dictionary<String, Object>((Dictionary<String, Object>)page.Session[objectName]);
                foreach (string key in defaultValues.Keys)
                {
                    if (!sessionFilterValues.Keys.Contains(key) || sessionFilterValues[key] == null)
                        sessionFilterValues.Add(key, defaultValues[key]);
                    else
                        sessionFilterValues[key] = defaultValues[key];
                }
                var t = (Dictionary<String, Object>)page.Session[objectName];
                return sessionFilterValues;
            }
            else
                return defaultValues;
        }

        /// <summary>
        /// Clears the Filter state which is maintained in session 
        /// so that the user can view all the records
        /// </summary>
        /// <param name="page"></param>
        /// <param name="table"></param>
        public static void ClearTableFilters(this Page page, MetaTable table)
        {
            var objectName = table.DataContextPropertyName;

            if (page.Session[objectName] != null)
                page.Session[objectName] = null;
        }

        /// <summary>
        /// Gets the values from the session and returns the browser familier verion
        /// for the query string which can be used for bookmarking the filter.
        /// </summary>
        /// <param name="page"></param>
        /// <param name="table"></param>
        /// <returns>String representation for the query string</returns>
        public static string GetQueryStringParameters(this Page page, MetaTable table)
        {
            StringBuilder queryString = new StringBuilder(" ");
            string objectName = table.DataContextPropertyName;

            if (page.Session[objectName] != null)
            {
                Dictionary<String, Object> sessionFilterValues = new Dictionary<String, Object>((Dictionary<String, Object>)page.Session[objectName]);
                queryString.Append("?");
                foreach (string key in sessionFilterValues.Keys)
                {
                    object value = sessionFilterValues[key];
                    queryString.Append(key);
                    queryString.Append("=");
                    queryString.Append(value.ToString());
                    queryString.Append("&");
                }
            }

            return queryString.ToString().Substring(0, queryString.ToString().Length - 1);
        }
    }
}
