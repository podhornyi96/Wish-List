using System.Runtime.Serialization;
using Newtonsoft.Json;
using ShopifyRest.Objects.Converters;

namespace ShopifyRest.Objects.Filters.Enums.FilterFields
{
    [JsonConverter(typeof(NullableEnumConverter<ShopifyOrderFiled>))]
    public enum ShopifyOrderFiled
    {
        [EnumMember(Value = "buyer_accepts_marketing")]
        BuyerAcceptsMarketing,
        [EnumMember(Value = "cancel_reason")]
        CancelReason,
        [EnumMember(Value = "cancelled_at")]
        CancelledAt,
        [EnumMember(Value = "cart_token")]
        CartToken,
        [EnumMember(Value = "checkout_token")]
        CheckoutToken,
        [EnumMember(Value = "closed_at")]
        ClosedAt,
        [EnumMember(Value = "confirmed")]
        Confirmed,
        [EnumMember(Value = "created_at")]
        CreatedAt,
        [EnumMember(Value = "currency")]
        Currency,
        [EnumMember(Value = "device_id")]
        DeviceId,
        [EnumMember(Value = "email")]
        Email,
        [EnumMember(Value = "financial_status")]
        FinancialStatus,
        [EnumMember(Value = "fulfillment_status")]
        FulfillmentStatus,
        [EnumMember(Value = "gateway")]
        Gateway,
        [EnumMember(Value = "id")]
        ID,
        [EnumMember(Value = "landing_site")]
        LandingSite,
        [EnumMember(Value = "location_id")]
        LocationId,
        [EnumMember(Value = "name")]
        Name,
        [EnumMember(Value = "discount_codes")]
        DiscountCodes,
        [EnumMember(Value = "note")]
        Note,
        [EnumMember(Value = "number")]
        Number,
        [EnumMember(Value = "processed_at")]
        ProcessedAt,
        [EnumMember(Value = "reference")]
        Reference,
        [EnumMember(Value = "referring_site")]
        ReferringSite,
        [EnumMember(Value = "source_identifier")]
        SourceIdentifier,
        [EnumMember(Value = "source_url")]
        SourceUrl,
        [EnumMember(Value = "subtotal_price")]
        SubtotalPrice,
        [EnumMember(Value = "taxes_included")]
        TaxesIncluded,
        [EnumMember(Value = "token")]
        Token,
        [EnumMember(Value = "total_discounts")]
        TotalDiscounts,
        [EnumMember(Value = "total_line_items_price")]
        TotalLineItemsPrice,
        [EnumMember(Value = "total_price")]
        TotalPrice,
        [EnumMember(Value = "total_price_usd")]
        TotalPriceUsd,
        [EnumMember(Value = "total_tax")]
        TotalTax,
        [EnumMember(Value = "total_weight")]
        TotalWeight,
        [EnumMember(Value = "updated_at")]
        UpdatedAt,
        [EnumMember(Value = "user_id")]
        UserId,
        [EnumMember(Value = "browser_ip")]
        BrowserIp,
        [EnumMember(Value = "landing_site_ref")]
        LandingSiteRef,
        [EnumMember(Value = "order_number")]
        OrderNumber,
        [EnumMember(Value = "fulfillments")]
        Fulfillments,
        [EnumMember(Value = "line_items")]
        LineItems,
        [EnumMember(Value = "billing_address")]
        BillingShopifyAddress,
        [EnumMember(Value = "shipping_address")]
        ShippingShopifyAddress,
        [EnumMember(Value = "payment_details")]
        ShopifyPaymentDetails,
        [EnumMember(Value = "source_name")]
        SourceName,
        [EnumMember(Value = "customer")]
        ShopifyCustomer,
        [EnumMember(Value = "client_details")]
        ShopifyClientDetails,
        [EnumMember(Value = "transactions")]
        Transactions
    }
}
