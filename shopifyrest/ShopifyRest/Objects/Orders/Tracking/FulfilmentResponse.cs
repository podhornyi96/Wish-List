using Newtonsoft.Json;

namespace ShopifyRest.Objects.Orders.Tracking
{
    class FulfilmentResponse
    {
        [JsonProperty("fulfillment")]
        public FulfillmentResponseItem Fulfillment { get; set; }

    }
}
