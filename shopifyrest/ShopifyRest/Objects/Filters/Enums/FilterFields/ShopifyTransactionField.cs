using System.Runtime.Serialization;
using Newtonsoft.Json;
using ShopifyRest.Objects.Converters;

namespace ShopifyRest.Objects.Filters.Enums.FilterFields
{
    [JsonConverter(typeof(NullableEnumConverter<ShopifyTransactionField>))]
    public enum ShopifyTransactionField
    {
        [EnumMember(Value = "amount")]
        Amount,
        [EnumMember(Value = "authorization")]
        Authorization,
        [EnumMember(Value = "created_at")]
        CreatedAt,
        [EnumMember(Value = "currency")]
        Currency,
        [EnumMember(Value = "gateway")]
        Gateway,
        [EnumMember(Value = "id")]
        ID,
        [EnumMember(Value = "kind")]
        Kind,
        [EnumMember(Value = "location_id")]
        LocationId,
        [EnumMember(Value = "message")]
        Message,
        [EnumMember(Value = "order_id")]
        OrderId,
        [EnumMember(Value = "parent_id")]
        ParentId,
        [EnumMember(Value = "status")]
        Status,
        [EnumMember(Value = "test")]
        Test,
        [EnumMember(Value = "user_id")]
        UserId,
        [EnumMember(Value = "device_id")]
        DeviceId,
        [EnumMember(Value = "error_code")]
        ErrorCode,
        [EnumMember(Value = "SourceName")]
        SourceName
    }
}
