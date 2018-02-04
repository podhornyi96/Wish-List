using System.Runtime.Serialization;
using Newtonsoft.Json;
using ShopifyRest.Objects.Converters;

namespace ShopifyRest.Objects.Filters.Enums.FilterFields
{
    [JsonConverter(typeof(NullableEnumConverter<ShopifyCustomerField>))]
    public enum ShopifyCustomerField
    {
        [EnumMember(Value = "id")]
        ID,
        [EnumMember(Value = "email")]
        Email,
        [EnumMember(Value = "accepts_marketing")]
        AcceptsMarkiting,
        [EnumMember(Value = "created_at")]
        CreatedAt,
        [EnumMember(Value = "updated_at")]
        UpdatedAt,
        [EnumMember(Value = "first_name")]
        FirstName,
        [EnumMember(Value = "last_name")]
        LastName,
        [EnumMember(Value= "orders_count")]
        OrdersCount,
        [EnumMember(Value = "stte")]
        State,
        [EnumMember(Value = "total_spent")]
        TotalSpent,
        [EnumMember(Value = "last_order_id")]
        LastOrderId,
        [EnumMember(Value = "note")]
        Note,
        [EnumMember(Value = "verified_email")]
        VerifiedEmail,
        [EnumMember(Value = "multipass_identifier")]
        MultipassIdentifier,
        [EnumMember(Value = "tax_exempt")]
        TaxExempt,
        [EnumMember(Value = "tags")]
        Tags,
        [EnumMember(Value = "last_order_name")]
        LastOrderName,
        [EnumMember(Value = "default_address")]
        DefaultShopifyAddress
    }
}
