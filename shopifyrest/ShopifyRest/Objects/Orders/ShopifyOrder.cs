// ***********************************************************************
// Assembly         :  .Marketplaces
// Author           : Alexander.K
// Created          : 09-02-2015
//
// Last Modified By : Alexander.K
// Last Modified On : 09-02-2015
// ***********************************************************************
// <copyright file="ShopifyOrder.cs" company=" ">
//     Copyright ©   2015
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using ShopifyRest.Objects.Address;
using ShopifyRest.Objects.Attributes;
using ShopifyRest.Objects.Enums;
using ShopifyRest.Objects.Orders.Tracking;
using ShopifyRest.Objects.Transactions;

namespace ShopifyRest.Objects.Orders
{
    /// <summary>
    /// Class ShopifyOrder.
    /// </summary>
    [ShopifyRootObject("order")]
    public class ShopifyOrder : IShopifyBaseObject
    {
        /// <summary>
        /// The mailing address associated with the payment method. This address is an optional field that will not be available on orders that do not require one. 
        /// </summary>
        [JsonProperty("billing_address")]
        public ShopifyAddress BillingAddress { get; set; }
        /// <summary>
        /// A <see cref="ShopifyCustomer"/> object containing information about the customer. This value may be null if the order was created through Shopify POS.
        /// </summary>
        [JsonProperty("customer")]
        public ShopifyCustomer Customer { get; set; }

        [JsonProperty("buyer_accepts_marketing")]
        public bool BuyerAcceptsMarketing { get; set; }

        [JsonProperty("cancel_reason")]
        public string CancelReason { get; set; }

        [JsonProperty("cancelled_at")]
        public string CancelledAt { get; set; }

        [JsonProperty("cart_token")]
        public string CartToken { get; set; }

        [JsonProperty("checkout_token")]
        public string CheckoutToken { get; set; }

        [JsonProperty("closed_at")]
        public DateTime? ClosedAt { get; set; }

        [JsonProperty("confirmed")]
        public bool Confirmed { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("device_id")]
        public string DeviceId { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("financial_status")]
        public ShopifyOrderFinancialStatus FinancialStatus { get; set; }

        [JsonProperty("fulfillment_status")]
        public string FulfillmentStatus { get; set; }

        [JsonProperty("gateway")]
        public string Gateway { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("landing_site")]
        public string LandingSite { get; set; }

        [JsonProperty("location_id")]
        public string LocationId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("discount_codes")]
        public List<ShopifyDiscount> DiscountCodes { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }

        [JsonProperty("number")]
        public long Number { get; set; }

        [JsonProperty("processed_at")]
        public DateTime? ProcessedAt { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("referring_site")]
        public string ReferringSite { get; set; }

        [JsonProperty("source_identifier")]
        public string SourceIdentifier { get; set; }

        [JsonProperty("source_url")]
        public string SourceUrl { get; set; }

        [JsonProperty("subtotal_price")]
        public float SubtotalPrice { get; set; }

        [JsonProperty("taxes_included")]
        public bool TaxesIncluded { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("total_discounts")]
        public float TotalDiscounts { get; set; }

        [JsonProperty("total_line_items_price")]
        public float TotalLineItemsPrice { get; set; }

        [JsonProperty("total_price")]
        public float TotalPrice { get; set; }

        [JsonProperty("total_price_usd")]
        public float TotalPriceUsd { get; set; }

        [JsonProperty("total_tax")]
        public float TotalTax { get; set; }

        [JsonProperty("total_weight")]
        public int? TotalWeight { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonProperty("user_id")]
        public long? UserId { get; set; }

        [JsonProperty("browser_ip")]
        public string BrowserIp { get; set; }

        [JsonProperty("landing_site_ref")]
        public string LandingSiteRef { get; set; }

        [JsonProperty("order_number")]
        public long OrderNumber { get; set; }

        [JsonProperty("fulfillments")]
        public List<ShopifyFulfillment> Fulfillments { get; set; }

        [JsonProperty("line_items")]
        public List<ShopifyLineItem> LineItems { get; set; }

        [JsonProperty("billing_address")]
        public ShopifyAddress BillingShopifyAddress { get; set; }

        [JsonProperty("shipping_address")]
        public ShopifyAddress ShippingShopifyAddress {get; set; }

        [JsonProperty("payment_details")]
        public ShopifyPaymentDetails ShopifyPaymentDetails { get; set; }

        [JsonProperty("source_name")]
        public string SourceName { get; set; }

        [JsonProperty("customer")]
        public ShopifyCustomer ShopifyCustomer { get; set; }

        [JsonProperty("client_details")]
        public ShopifyClientDetails ShopifyClientDetails { get; set; }

        [JsonProperty("transactions")]
        public List<ShopifyTransaction> Transactions { get; set; }
        
    }
}
