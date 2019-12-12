using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;
using DynamicDataExtensions.Attributes;
using DynamicDataExtensions.Attributes.ExtensionMethods;
using System.Web.UI.HtmlControls;
using System.Collections;

namespace Footsteps
{
    public partial class MultiColumnEntityTemplate_Insert : System.Web.DynamicData.EntityTemplateUserControl
    {
        private const string COLUMNS = "Columns";
        private const string TITLE_CSS_CLASS = "TitleCssClass";
        private const string FIELD_CSS_CLASS = "FieldCssClass";

        protected override void OnLoad(EventArgs e)
        {
            // get columns from table
            var metaColumns = Table.GetScaffoldColumns(Mode, ContainerType).ToList();

            // get the total columns in the table including any spanned columns
            var totalNoOfCells = metaColumns.Select(c => c.GetAttributeOrDefault<MultiColumnAttribute>().ColumnSpan).Sum();

            // CSS Styles
            String titleCssClass = String.Empty;
            String fieldCssClass = String.Empty;

            // set default number of columns
            int tableColumns = 2;
            var entityUHint = Table.GetAttribute<EntityUIHintAttribute>();
            if (entityUHint != null)
            {
                // get custom number of columns
                if (entityUHint.ControlParameters.Keys.Contains(COLUMNS))
                    tableColumns = (int)entityUHint.ControlParameters[COLUMNS];

                // get title CSS class
                if (entityUHint.ControlParameters.Keys.Contains(TITLE_CSS_CLASS))
                    titleCssClass = entityUHint.ControlParameters[TITLE_CSS_CLASS].ToString();

                // get the field CSS class
                if (entityUHint.ControlParameters.Keys.Contains(FIELD_CSS_CLASS))
                    fieldCssClass = entityUHint.ControlParameters[FIELD_CSS_CLASS].ToString();
            }

            // get the number of rows
            var tableRows = totalNoOfCells / tableColumns; 
            
            // incase of Odd number of Columns in the database Table
            if ((totalNoOfCells % tableColumns) != 0)
                tableRows += 1;

            for (int rowNo = 0; rowNo < tableRows; rowNo++)
            {
                // header row
                var headerRow = new HtmlTableRow();
                headerRow.Attributes.Add("style", "font-weight: bolder;");
                if (!String.IsNullOrEmpty(titleCssClass))
                    headerRow.Attributes.Add("class", titleCssClass);
                for (int colNo = 0; colNo < tableColumns; colNo++)
                {
                    var index = (rowNo * tableColumns) + colNo;
                    if (index < totalNoOfCells)
                    {
                        var metaColumn = metaColumns[index];

                        // get new cell TD
                        var td = new HtmlTableCell();

                        // add the label
                        var label = new Label();
                        label.Text = metaColumn.DisplayName;
                        //if (Mode != DataBoundControlMode.ReadOnly)
                        //    label.PreRender += Label_PreRender;
                        td.Controls.Add(label);

                        var multiColumn = metaColumn.GetAttributeOrDefault<MultiColumnAttribute>();
                        if (multiColumn.ColumnSpan > 1)
                        {
                            td.ColSpan = multiColumn.ColumnSpan;
                            colNo += multiColumn.ColumnSpan;
                        }
                        headerRow.Cells.Add(td);
                    }
                    else
                    {
                        var th = new HtmlTableCell();
                        th.InnerHtml = "&nbsp;";
                        headerRow.Cells.Add(th);
                    }
                }
                this.Controls.Add(headerRow);

                // data row
                var dataRow = new HtmlTableRow();
                if (!String.IsNullOrEmpty(fieldCssClass))
                    dataRow.Attributes.Add("class", fieldCssClass);
                for (int col = 0; col < tableColumns; col++)
                {
                    var index = (rowNo * tableColumns) + col;
                    if (index < totalNoOfCells)
                    {
                        var metaColumn = metaColumns[index];

                        // get new cell TD
                        var td = new HtmlTableCell();

                        // add new dynamic control
                        var dynamicControl = new DynamicControl(Mode);
                        dynamicControl.DataField = metaColumn.Name;
                        dynamicControl.ValidationGroup = this.ValidationGroup;
                        td.Controls.Add(dynamicControl);

                        var multiColumn = metaColumn.GetAttributeOrDefault<MultiColumnAttribute>();
                        if (multiColumn.ColumnSpan > 1)
                        {
                            td.ColSpan = multiColumn.ColumnSpan;
                            col += multiColumn.ColumnSpan;
                        }
                        dataRow.Cells.Add(td);
                    }
                    else
                    {
                        var td = new HtmlTableCell();
                        td.InnerHtml = "&nbsp;";
                        dataRow.Cells.Add(td);
                    }
                }
                this.Controls.Add(dataRow);
            }
        }

        //protected void Label_PreRender(object sender, EventArgs e)
        //{
        //    Label label = (Label)sender;
        //    DynamicControl dynamicControl = (DynamicControl)label.Parent.FindControl("DynamicControl");
        //    FieldTemplateUserControl ftuc = dynamicControl.FieldTemplate as FieldTemplateUserControl;

        //    if (ftuc != null && ftuc.DataControl != null)
        //        label.AssociatedControlID = ftuc.DataControl.GetUniqueIDRelativeTo(label);
        //}
    }
}
