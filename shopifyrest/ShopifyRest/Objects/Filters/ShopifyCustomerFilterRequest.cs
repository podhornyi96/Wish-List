using System.Collections.Generic;
using ShopifyRest.Objects.Attributes;
using ShopifyRest.Objects.Filters.Enums.FilterFields;

namespace ShopifyRest.Objects.Filters
{
    public class ShopifyCustomerFilterRequest : ShopifyBaseFilterRequest
    {
        [ShopifyFilterObject("ids")]
        public List<long> IDs { get; set; } = new List<long>();

        [ShopifyFilterObject("fields")]
        public List<ShopifyCustomerField> Fields { get; set; } = new List<ShopifyCustomerField>();
    }
}
