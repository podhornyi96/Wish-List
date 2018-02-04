using Newtonsoft.Json;

namespace ShopifyRest.Objects.Orders.Tracking
{
    public class FulfillmentRequest
    {
        [JsonProperty("fulfillment")]
        public ShopifyFulfillment Fulfillment { get; set; }

        public FulfillmentRequest(ShopifyFulfillment data)
        {
            Fulfillment = data;
        }
    }
}
