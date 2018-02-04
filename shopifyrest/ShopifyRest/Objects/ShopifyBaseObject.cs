using Newtonsoft.Json;

namespace ShopifyRest.Objects
{
    public interface IShopifyBaseObject
    {
        [JsonProperty("id")]
        long Id { get; set; }
    }
}
