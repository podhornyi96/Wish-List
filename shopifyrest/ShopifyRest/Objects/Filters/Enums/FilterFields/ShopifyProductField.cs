using System.Runtime.Serialization;
using Newtonsoft.Json;
using ShopifyRest.Objects.Converters;

namespace ShopifyRest.Objects.Filters.Enums.FilterFields
{
    [JsonConverter(typeof(NullableEnumConverter<ShopifyProductField>))]
    public enum ShopifyProductField
    {
        [EnumMember(Value = "id")]
        ID,
        [EnumMember(Value = "title")]
        Title,
        [EnumMember(Value = "handle")]
        Handle,
        [EnumMember(Value = "variants")]
        Variants,
        [EnumMember(Value = "vendor")]
        Vendor,
        [EnumMember(Value = "product_type")]
        ProductType,
        [EnumMember(Value = "published_at")]
        PublishedAt,
        [EnumMember(Value = "body_html")]
        Body,
        [EnumMember(Value = "images")]
        Images,
        [EnumMember(Value = "tags")]
        Tags,
        [EnumMember(Value = "published_scope")]
        PublishedScope,
    }
}
