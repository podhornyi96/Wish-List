using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Objects.Common;
using BL.Objects.Product;

namespace BL.Objects.Lists.Product
{
    public class ProductList : BaseEntity
    {
        public string OwnerId { get; set; }
        public long StoreId { get; set; }
        public long? EventListId { get; set; }
        public string Title { get; set; }
        public List<ProductItem> ProductItems { get; set; } = new List<ProductItem>();
    }
}
