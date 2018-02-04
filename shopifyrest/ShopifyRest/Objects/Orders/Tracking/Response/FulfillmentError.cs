using System.Collections.Generic;
using Newtonsoft.Json;

namespace ShopifyRest.Objects.Orders.Tracking.Response
{
    public class FulfillmentError
    {
        [JsonProperty("order")]
        public List<string> Order { get; set; }
    }
}
