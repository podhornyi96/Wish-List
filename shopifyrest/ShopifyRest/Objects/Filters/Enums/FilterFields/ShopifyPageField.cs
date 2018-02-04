using System.Runtime.Serialization;
using Newtonsoft.Json;
using ShopifyRest.Objects.Converters;

namespace ShopifyRest.Objects.Filters.Enums.FilterFields
{
    [JsonConverter(typeof(NullableEnumConverter<ShopifyPageField>))]
    public enum ShopifyPageField
    {
        [EnumMember(Value = "title")]
        Title,
        [EnumMember(Value = "body_html")]
        BodyHtml,
        [EnumMember(Value = "created_at")]
        CreatedAt,
        [EnumMember(Value = "updated_at")]
        UpdatedAt,
        [EnumMember(Value = "published_at")]
        PublishedAt,
        [EnumMember(Value = "handle")]
        Handle,
        [EnumMember(Value = "template_suffix")]
        TemplateSuffix,
        [EnumMember(Value = "metafields")]
        Metafields
    }
}
