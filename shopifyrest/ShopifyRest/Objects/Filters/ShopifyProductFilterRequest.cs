using System;
using System.Collections.Generic;
using ShopifyRest.Objects.Attributes;
using ShopifyRest.Objects.Filters.Enums;
using ShopifyRest.Objects.Filters.Enums.FilterFields;

namespace ShopifyRest.Objects.Filters
{
    public class ShopifyProductFilterRequest : ShopifyBaseFilterRequest
    {
        [ShopifyFilterObject("ids")]
        public List<long> IDs { get; set; } = new List<long>();

        [ShopifyFilterObject("title")]
        public string Title { get; set; } 

        [ShopifyFilterObject("vendor")]
        public string Vendor { get; set; }

        [ShopifyFilterObject("handle")]
        public string Handle { get; set; }

        [ShopifyFilterObject("product_type")]
        public string ProductType { get; set; }

        [ShopifyFilterObject("collection_id")]
        public long? CollectionID { get; set; }

        [ShopifyFilterObject("published_at_min")]
        public DateTime? PublishedAtMin { get; set; }

        [ShopifyFilterObject("published_at_max")]
        public DateTime? PublishedAtMax { get; set; }

        [ShopifyFilterObject("published_status")]
        public ShopifyPublishedStatus? PublishedStatus { get; set; } = ShopifyPublishedStatus.Any;

        [ShopifyFilterObject("fields")]
        public List<ShopifyProductField> Fields { get; set; } = new List<ShopifyProductField>();
    }
}
