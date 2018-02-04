using System.Collections.Generic;
using ShopifyRest.Objects.Attributes;
using ShopifyRest.Objects.Filters.Enums.FilterFields;

namespace ShopifyRest.Objects.Filters
{
    public class ShopifyTransactionFilterRequest : ShopifyBaseFilterRequest
    {
        [ShopifyFilterObject("field")]
        public List<ShopifyTransactionField> Fields { get; set; } = new List<ShopifyTransactionField>();
    }
}
