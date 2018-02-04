using Newtonsoft.Json;
using ShopifyRest.Objects.Attributes;

namespace ShopifyRest.Objects.Transactions
{
    [ShopifyRootObject("transaction")]
    public class ShopifyTransaction : IShopifyBaseObject
    {
        [JsonProperty("amount")]
        public float? Amount { get; set; }

        [JsonProperty("authorization")]
        public string Authorization { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("gateway")]
        public string Gateway { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("location_id")]
        public string LocationId { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("order_id")]
        public long OrderId { get; set; }

        [JsonProperty("parent_id")]
        public long? ParentId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("test")]
        public bool Test { get; set; }

        [JsonProperty("user_id")]
        public long? UserId { get; set; }

        [JsonProperty("device_id")]
        public long? DeviceId { get; set; }

        [JsonProperty("error_code")]
        public string ErrorCode { get; set; }

        [JsonProperty("SourceName")]
        public string SourceName { get; set; }
    }
}
