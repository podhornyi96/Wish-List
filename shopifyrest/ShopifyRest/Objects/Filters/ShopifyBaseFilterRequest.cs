using System;
using ShopifyRest.Objects.Attributes;

namespace ShopifyRest.Objects.Filters
{
    public class ShopifyBaseFilterRequest
    {
        [ShopifyFilterObject("created_at_min")]
        public DateTime? CreatedAtMin { get; set; }

        [ShopifyFilterObject("created_at_max")]
        public DateTime? CreatedAtMax { get; set; }

        [ShopifyFilterObject("updated_at_min")]
        public DateTime? UpdatedAtMin { get; set; }

        [ShopifyFilterObject("updated_at_max")]
        public DateTime? UpdatedAtMax { get; set; }

        [ShopifyFilterObject("limit")]
        public int? Limit { get; set; }

        [ShopifyFilterObject("page")]
        public int? Page { get; set; }

        [ShopifyFilterObject("since_id")]
        public long? SinceID { get; set; }
    }
}
