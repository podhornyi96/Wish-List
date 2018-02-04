using System.Runtime.Serialization;
using Newtonsoft.Json;
using ShopifyRest.Objects.Converters;

namespace ShopifyRest.Objects.Filters.Enums.FilterFields
{
    [JsonConverter(typeof(NullableEnumConverter<ShopifyFulfillmentField>))]
    public enum ShopifyFulfillmentField
    {
        [EnumMember(Value = "id")]
        ID,
        [EnumMember(Value = "tracking_number")]
        TrackingNumber,
        [EnumMember(Value = "tracking_numbers")]
        TrackingNumbers,
        [EnumMember(Value = "status")]
        Status,
        [EnumMember(Value = "notify_customer")]
        NotifyCustomer,
        [EnumMember(Value = "tracking_company")]
        TrackingCompany,
        [EnumMember(Value = "tracking_url")]
        TrackingUrl,
        [EnumMember(Value = "order_id")]
        OrderId,
        [EnumMember(Value = "created_at")]
        CreatedAt
    }
}
