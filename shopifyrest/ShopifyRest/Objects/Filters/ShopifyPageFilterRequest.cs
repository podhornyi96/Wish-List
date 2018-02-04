using System;
using System.Collections.Generic;
using ShopifyRest.Objects.Attributes;
using ShopifyRest.Objects.Filters.Enums;
using ShopifyRest.Objects.Filters.Enums.FilterFields;

namespace ShopifyRest.Objects.Filters
{
    public class ShopifyPageFilterRequest : ShopifyBaseFilterRequest
    {
        [ShopifyFilterObject("title")]
        public string Title { get; set; }

        [ShopifyFilterObject("handle")]
        public string Handle { get; set; }

        [ShopifyFilterObject("published_at_min")]
        public DateTime? PublishedAtMin { get; set; }

        [ShopifyFilterObject("published_at_max")]
        public DateTime? PublishedAtMax { get; set; }

        [ShopifyFilterObject("fields")]
        public List<ShopifyPageField> Fields { get; set; } = new List<ShopifyPageField>();

        [ShopifyFilterObject("published_status")]
        public ShopifyPublishedStatus PublishedStatus { get; set; }
    }
}
