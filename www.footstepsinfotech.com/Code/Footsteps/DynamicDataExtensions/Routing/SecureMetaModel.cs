using System.Web.DynamicData;
using System.Web.DynamicData.ModelProviders;
using DynamicDataExtensions.Routing;

namespace DynamicDataExtensions.Routing
{
    public class SecureMetaModel : MetaModel
    {
        /// <summary>
        /// Creates the table.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <returns></returns>
        protected override MetaTable CreateTable(TableProvider provider)
        {
            return new SecureMetaTable(this, provider);
        }
    }
}
