using System;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Web.DynamicData;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Web.DynamicData;
using DynamicDataExtensions.Attributes;
using DynamicDataExtensions.Attributes.ExtensionMethods;

namespace Footsteps
{
    public partial class Decimal_EditField : System.Web.DynamicData.FieldTemplateUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox1.ToolTip = Column.Description;

            SetUpValidator(RequiredFieldValidator1);
            SetUpValidator(CompareValidator1);
            SetUpValidator(RegularExpressionValidator1);
            SetUpValidator(RangeValidator1);
            SetUpValidator(DynamicValidator1);

            this.SetUpDomainValidator(DomainValidator1);
            SetUpValidator(DomainValidator1);

            var decimalAttribute = Column.GetAttribute<DecimalAttribute>();
            if (decimalAttribute != null)
            {
                AdditionalInfoLabel.Text = decimalAttribute.Postfix;
                AdditionalInfoLabel.ToolTip = Column.Description;
                AdditionalInfoLabel.Visible = true;
            }
        }

        protected override void ExtractValues(IOrderedDictionary dictionary)
        {
            dictionary[Column.Name] = ConvertEditedValue(TextBox1.Text);
        }

        public override Control DataControl
        {
            get
            {
                return TextBox1;
            }
        }

    }
}
