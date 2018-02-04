using System.Runtime.Serialization;
using Newtonsoft.Json;
using ShopifyRest.Objects.Converters;

namespace ShopifyRest.Objects.Filters.Enums.FilterFields
{
    [JsonConverter(typeof(NullableEnumConverter<ShopifyAssetField>))]
    public enum ShopifyAssetField
    {
        [EnumMember(Value = "attachment")]
        Attachment,
        [EnumMember(Value = "content_type")]
        ContentType,
        [EnumMember(Value = "created_at")]
        CreatedAt,
        [EnumMember(Value = "key")]
        Key,
        [EnumMember(Value = "public_url")]
        PublicUrl,
        [EnumMember(Value = "size")]
        Size,
        [EnumMember(Value = "source_key")]
        SourceKey,
        [EnumMember(Value = "src")]
        Src,
        [EnumMember(Value = "updated_at")]
        UpdatedAt,
        [EnumMember(Value = "value")]
        Value,
    }
}
