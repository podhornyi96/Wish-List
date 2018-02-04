using System;
using ShopifyRest.Objects.Attributes;

namespace ShopifyRest.Objects.Filters
{
    public class ShopifyProductImageFilterRequest : ShopifyBaseFilterRequest
    {
        [ShopifyFilterObject("published_at_min")]
        public DateTime? PublishedAtMin { get; set; }

        [ShopifyFilterObject("published_at_max")]
        public DateTime? PublishedAtMax { get; set; }
    }
}
