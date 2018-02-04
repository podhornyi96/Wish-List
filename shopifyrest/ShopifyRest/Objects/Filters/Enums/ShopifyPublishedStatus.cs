using System.Runtime.Serialization;
using Newtonsoft.Json;
using ShopifyRest.Objects.Converters;

namespace ShopifyRest.Objects.Filters.Enums
{
    [JsonConverter(typeof(NullableEnumConverter<ShopifyPublishedStatus>))]
    public enum ShopifyPublishedStatus  
    {
        [EnumMember(Value = "published")]
        Published,
        [EnumMember(Value = "unpublished")]
        Unpublished ,
        [EnumMember(Value = "any")]
        Any
    }
}
