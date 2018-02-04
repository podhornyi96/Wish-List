using Newtonsoft.Json;

namespace ShopifyRest.Objects.Orders
{
    public class ShopifyDiscount
    {
        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("amount")]
        public float Amount { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }

        public ShopifyDiscount(ShopifyDiscount shopifyDiscount)
        {
            if (shopifyDiscount == null)
                return;
            Code = shopifyDiscount.Code;
            Amount = shopifyDiscount.Amount;
            Type = shopifyDiscount.Type;
        }
    }
}
