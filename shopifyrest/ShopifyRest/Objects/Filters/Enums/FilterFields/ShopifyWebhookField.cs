using System.Runtime.Serialization;
using Newtonsoft.Json;
using ShopifyRest.Objects.Converters;

namespace ShopifyRest.Objects.Filters.Enums.FilterFields
{
    [JsonConverter(typeof(NullableEnumConverter<ShopifyWebhookField>))]
    public enum ShopifyWebhookField
    {
        [EnumMember(Value = "address")]
        Address,
        [EnumMember(Value = "created_at")]
        CreatedAt,
        [EnumMember(Value = "fields")]
        Fields,
        [EnumMember(Value = "format")]
        Format,
        [EnumMember(Value = "metafield_namespaces")]
        MetafieldNamespaces,
        [EnumMember(Value = "topic")]
        Topic,
        [EnumMember(Value = "updated_at")]
        UpdatedAt
    }
}
