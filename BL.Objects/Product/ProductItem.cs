using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopifyRest.Objects.Products;

namespace BL.Objects.Product
{
    public class ProductItem
    {
        public long ProductListId { get; set; }
        public long ProductId { get; set; }
        public long VariantId { get; set; }
        public ShopifyProduct Product { get; set; }
    }
}
