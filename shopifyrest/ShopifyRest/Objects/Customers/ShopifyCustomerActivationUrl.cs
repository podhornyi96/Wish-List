using Newtonsoft.Json;

namespace ShopifyRest.Objects.Customers
{
    public class ShopifyCustomerActivationUrl
    {
        [JsonProperty("account_activation_url")]
        public string ActivationUrl { get; set; }
    }
}