using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.DynamicData;
using System.Web.DynamicData.ModelProviders;
using System.Web.UI.WebControls;
using DynamicDataExtensions.Attributes.ExtensionMethods;

namespace DynamicDataExtensions.Routing
{
    public class SecureMetaTable : MetaTable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SecureMetaTable"/> class.
        /// </summary>
        /// <param name="metaModel">The meta model.</param>
        /// <param name="tableProvider">The table provider.</param>
        public SecureMetaTable(MetaModel metaModel, TableProvider tableProvider) :
            base(metaModel, tableProvider) { }

        /// <summary>
        /// Initializes data that may not be available when the constructor is called.
        /// </summary>
        protected override void Initialize() { base.Initialize(); }

        protected override MetaColumn CreateColumn(ColumnProvider columnProvider)
        {
            return new SecureMetaColumn(this, columnProvider);
        }

        protected override MetaChildrenColumn CreateChildrenColumn(ColumnProvider columnProvider)
        {
            return new SecureMetaChildrenColumn(this, columnProvider);
        }

        protected override MetaForeignKeyColumn CreateForeignKeyColumn(ColumnProvider columnProvider)
        {
            return new SecureMetaForeignKeyColumn(this, columnProvider);
        }

        /// <summary>
        /// Gets the scaffold columns.
        /// </summary>
        /// <param name="mode">The mode.</param>
        /// <param name="containerType">Type of the container.</param>
        /// <returns></returns>
        public override IEnumerable<MetaColumn> GetScaffoldColumns(DataBoundControlMode mode, ContainerType containerType)
        {
            var visibleColumn = base.GetScaffoldColumns(mode, containerType);
            var secureColumns = from column in visibleColumn
                                where column.ColumnIsVisible()
                                select column;
            return secureColumns;
        }
    }
}
