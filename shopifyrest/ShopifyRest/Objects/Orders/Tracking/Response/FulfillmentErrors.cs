using Newtonsoft.Json;

namespace ShopifyRest.Objects.Orders.Tracking.Response
{
    public class FulfillmentErrors
    {
        [JsonProperty("errors")]
        public FulfillmentError Errors { get; set; }

    }
}
