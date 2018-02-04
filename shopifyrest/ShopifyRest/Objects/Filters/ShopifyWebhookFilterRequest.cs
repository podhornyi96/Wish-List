using System.Collections.Generic;
using ShopifyRest.Objects.Attributes;
using ShopifyRest.Objects.Filters.Enums;
using ShopifyRest.Objects.Filters.Enums.FilterFields;

namespace ShopifyRest.Objects.Filters
{
    public class ShopifyWebhookFilterRequest : ShopifyBaseFilterRequest
    {
        [ShopifyFilterObject("address")]
        public string Address { get; set; }

        [ShopifyFilterObject("fileds")]
        public List<ShopifyWebhookField> Fields { get; set; } = new List<ShopifyWebhookField>();

        [ShopifyFilterObject("topic")]
        public ShopifyWebhookTopic? Topic { get; set; }
    }
}
