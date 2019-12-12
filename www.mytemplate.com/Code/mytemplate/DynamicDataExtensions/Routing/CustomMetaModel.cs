using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

using System.Web.DynamicData;
using System.Web.DynamicData.ModelProviders;

namespace DynamicDataExtensions.Routing
{
    public class CustomMetaModel : SecureMetaModel
    {
        /// <summary>
        /// Delegate to allow custom column generator to be passed in.
        /// </summary>
        public delegate IEnumerable<MetaColumn> GetVisibleColumns(IEnumerable<MetaColumn> columns);

        private GetVisibleColumns _getVisdibleColumns;

        public CustomMetaModel() { }

        public CustomMetaModel(GetVisibleColumns getVisdibleColumns)
        {
            _getVisdibleColumns = getVisdibleColumns;
        }

        protected override MetaTable CreateTable(TableProvider provider)
        {
            if (_getVisdibleColumns == null)
                return new CustomMetaTable(this, provider);
            else
                return new CustomMetaTable(this, provider, _getVisdibleColumns);
        }
    }
}
