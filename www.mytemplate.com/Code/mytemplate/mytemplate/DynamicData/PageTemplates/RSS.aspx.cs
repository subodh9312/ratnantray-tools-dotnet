using System;
using System.Linq;
using System.Web.DynamicData;
using Microsoft.Web.DynamicData;
using System.Reflection;
using System.Text;
using System.Web.UI.WebControls;
using mytemplate.Controller.Utilities;

namespace mytemplate
{
    public partial class RSS : System.Web.UI.Page
    {
        protected MetaTable table;
        StringBuilder description = new StringBuilder();
        StringBuilder title = new StringBuilder();
        StringBuilder link = new StringBuilder();

        protected void Page_Init(object sender, EventArgs e)
        {
            table = DynamicDataRouteHandler.GetRequestMetaTable(Context);
            GridView1.SetMetaTable(table);

            DetailsDataSource.DomainServiceTypeName = table.DataContextType.AssemblyQualifiedName;
            DetailsDataSource.QueryName = table.GetSelectMethod();
            GridView1.DataKeyNames = table.PrimaryKeyColumns.Select(c => c.Name).ToArray();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                object CurObj = e.Row.DataItem;
                
                PropertyInfo[] fields = CurObj.GetType().GetProperties();
                foreach (PropertyInfo pi in fields)
                {
                    if (pi.Name == "OriginalId" || pi.Name == "EntityState" || pi.Name == "EntityKey")
                        continue;
                    MetaColumn column;

                    if (!table.TryGetColumn(pi.Name, out column))
                        continue;
                    
                    if (pi.Name == "Id")
                    {
                        link.Append(table.GetActionPath(PageAction.Details, CurObj));
                        link.Append("$");
                        continue;
                    }
                    else if (pi.Name == "Name") // to get the title link
                    {
                        title.Append(pi.GetValue(CurObj, null));
                        title.Append("$");
                    }
                    description.Append("<strong>");
                    description.Append(column.DisplayName);
                    description.Append(":</strong> ");
                    if (column.IsInteger && column.GetEnumType() != null
                                && column.GetEnumType().IsEnum)
                    {
                        // get Enum Value
                        Type enumType = column.GetEnumType();
                        string display = enumType.GetEnumName(pi.GetValue(CurObj, null));
                        description.Append(display);
                    }
                    else if (table.GetColumn(pi.Name).ColumnType == typeof(bool))
                    {
                        if (pi.GetValue(CurObj, null) != null)
                        {
                            bool value = (bool)pi.GetValue(CurObj, null);
                            if (value)
                                description.Append("Yes");
                            else
                                description.Append("No");
                        }
                    }
                    else
                        description.Append(pi.GetValue(CurObj, null));
                    description.Append("<br />");
                }
                description.Append("$");
            }
        }

        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            GridView1.Visible = false;
            RSSUtility.GenerateRssResponseXML(Response, title, description, link, table.DisplayName);
        }
    }
}
