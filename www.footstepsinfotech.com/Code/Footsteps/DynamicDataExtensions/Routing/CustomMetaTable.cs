using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Web;
using System.Web.DynamicData;
using System.Web.DynamicData.ModelProviders;
using System.Web.UI.WebControls;
using System.ComponentModel.DataAnnotations;

namespace DynamicDataExtensions.Routing
{
    public class CustomMetaTable : SecureMetaTable
    {
        private CustomMetaModel.GetVisibleColumns _getVisdibleColumns;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomMetaTable"/> class.
        /// </summary>
        /// <param name="metaModel">The entity meta model.</param>
        /// <param name="tableProvider">The entity model provider.</param>
        public CustomMetaTable(MetaModel metaModel, TableProvider tableProvider) :
            base(metaModel, tableProvider) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomMetaTable"/> class.
        /// </summary>
        /// <param name="metaModel">The meta model.</param>
        /// <param name="tableProvider">The table provider.</param>
        /// <param name="getVisibleColumns">Delegate to get the visible columns.</param>
        public CustomMetaTable(
            MetaModel metaModel,
            TableProvider tableProvider,
            CustomMetaModel.GetVisibleColumns getVisibleColumns) :
            base(metaModel, tableProvider)
        {
            _getVisdibleColumns = getVisibleColumns;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        public override IEnumerable<MetaColumn> GetScaffoldColumns(
            DataBoundControlMode mode,
            ContainerType containerType)
        {
            if (_getVisdibleColumns == null)
                return base.GetScaffoldColumns(mode, containerType);
            else
                return _getVisdibleColumns(base.GetScaffoldColumns(mode, containerType));
        }
    }
}
