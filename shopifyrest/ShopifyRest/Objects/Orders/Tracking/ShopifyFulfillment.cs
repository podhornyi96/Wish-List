using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using ShopifyRest.Objects.Attributes;

namespace ShopifyRest.Objects.Orders.Tracking
{
    [ShopifyRootObject("fulfillment")]
    public class ShopifyFulfillment : IShopifyBaseObject
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("tracking_number")]
        public string TrackingNumber { get; set; }

        [JsonProperty("tracking_numbers")]
        public List<string> TrackingNumbers { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("notify_customer")]
        public bool NotifyCustomer { get; set; }

        [JsonProperty("tracking_company")]
        public string TrackingCompany { get; set; }

        [JsonProperty("tracking_url")]
        public string TrackingUrl { get; set; }

        [JsonProperty("order_id")]
        public long OrderId { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
    }
}
