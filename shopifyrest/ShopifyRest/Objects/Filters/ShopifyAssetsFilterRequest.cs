using System.Collections.Generic;
using ShopifyRest.Objects.Attributes;
using ShopifyRest.Objects.Filters.Enums.FilterFields;

namespace ShopifyRest.Objects.Filters
{
    public class ShopifyAssetsFilterRequest 
    {
        [ShopifyFilterObject("fields")]
        public List<ShopifyAssetField> Fields { get; set; } = new List<ShopifyAssetField>();
    }
}
