using System;
using System.Collections.Specialized;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace mytemplate
{
    public partial class Milestone_EditField : FieldTemplateUserControl
    {
        protected override void OnDataBinding(EventArgs e)
        {
            base.OnDataBinding(e);
            string[] Options = FieldValueEditString.Split(',');

            foreach (string str in Options)
            {
                MileStones.Items.Add(new ListItem(str));
            }
        }

        protected override void ExtractValues(IOrderedDictionary dictionary)
        {
            dictionary[Column.Name] = ConvertEditedValue(MileStones.Text);
        }

        public override Control DataControl
        {
            get
            {
                return MileStones;
            }
        }

    }
}
