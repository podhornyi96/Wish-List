using System.Runtime.Serialization;
using Newtonsoft.Json;
using ShopifyRest.Objects.Converters;

namespace ShopifyRest.Objects.Filters.Enums
{
    [JsonConverter(typeof(NullableEnumConverter<ShopifyOrderStatus>))]
    public enum ShopifyOrderStatus
    {
        [EnumMember(Value = "open")]
        Open,

        [EnumMember(Value = "closed")]
        Closed,

        [EnumMember(Value = "cancelled")]
        Cancelled,

        [EnumMember(Value = "any")]
        Any
    }
}
