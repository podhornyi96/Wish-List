using System;
using System.Collections.Generic;
using ShopifyRest.Objects.Attributes;
using ShopifyRest.Objects.Filters.Enums;
using ShopifyRest.Objects.Filters.Enums.FilterFields;

namespace ShopifyRest.Objects.Filters
{
    public class ShopifyOrderFilterRequest : ShopifyBaseFilterRequest
    {
        [ShopifyFilterObject("ids")]
        public List<long> IDs { get; set; } = new List<long>();

        [ShopifyFilterObject("processed_at_min")]
        public DateTime? ProcessedAtMin { get; set; }

        [ShopifyFilterObject("processed_at_max")]
        public DateTime? ProccesedAtMax { get; set; }

        [ShopifyFilterObject("status")]
        public ShopifyOrderStatus? Status { get; set; }

        [ShopifyFilterObject("financial_status")]
        public ShopifyOrderFinancialStatus? FunancialStatus { get; set; }

        [ShopifyFilterObject("fulfillment_status")]
        public ShopifyFulfillmentStatus? FulfillmentStatus { get; set; }

        [ShopifyFilterObject("fields")]
        public List<ShopifyOrderFiled> Fields { get; set; } = new List<ShopifyOrderFiled>();
    }
}
