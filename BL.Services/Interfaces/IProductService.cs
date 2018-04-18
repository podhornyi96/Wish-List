using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Objects.Requests;
using ShopifyRest.Objects.Products;

namespace BL.Services.Interfaces
{
    public interface IProductService
    {
        IEnumerable<ShopifyProduct> Search(ProductSearchRequest request);
    }
}
