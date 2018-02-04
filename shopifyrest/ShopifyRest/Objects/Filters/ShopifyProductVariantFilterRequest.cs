using System.Collections.Generic;
using ShopifyRest.Objects.Attributes;
using ShopifyRest.Objects.Filters.Enums.FilterFields;

namespace ShopifyRest.Objects.Filters
{
    public class ShopifyProductVariantFilterRequest
    {
        [ShopifyFilterObject("fields")]
        public List<ShopifyProductVariantField> Fields { get; set; } = new List<ShopifyProductVariantField>();

        [ShopifyFilterObject("limit")]
        public int? Limit { get; set; }

        [ShopifyFilterObject("page")]
        public int? Page { get; set; }

        [ShopifyFilterObject("since_id")]
        public long? SinceID { get; set; }
    }
}
