using System.Collections.Generic;
using ShopifyRest.Objects.Attributes;
using ShopifyRest.Objects.Filters.Enums.FilterFields;

namespace ShopifyRest.Objects.Filters
{
    public class ShopifyFulfillmentFilterRequest : ShopifyBaseFilterRequest
    {
        [ShopifyFilterObject("fields")]
        public List<ShopifyFulfillmentField> Fields { get; set; } = new List<ShopifyFulfillmentField>();
    }
}
