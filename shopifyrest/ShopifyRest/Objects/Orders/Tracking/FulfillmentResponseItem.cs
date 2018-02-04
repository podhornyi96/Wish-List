using System.Collections.Generic;
using Newtonsoft.Json;

namespace ShopifyRest.Objects.Orders.Tracking
{
    public class FulfillmentResponseItem : ShopifyFulfillment
    {
        [JsonProperty("line_items")]
        public List<ShopifyLineItem> LineItems { get; set; }
    }
}
