using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Objects.Common;
using BL.Objects.Lists.Product;

namespace DAL.Interfaces
{
    public interface IProductListRepository
    {
        SearchResponse<ProductList> Get(object obj);
        long Modify(ProductList productList);
        void Delete(object obj);
    }
}
