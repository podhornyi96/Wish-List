using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Objects.Common;
using BL.Objects.Lists.Product;
using BL.Objects.Requests;

namespace BL.Services.Interfaces
{
    public interface IProductListService
    {
        ProductList GetById(long id);
        List<ProductList> GetByIds(List<long> ids);
        SearchResponse<ProductList> Search(ProductListSearchRequest request);
        long Modify(ProductList productList);
        void Delete(long id);
        void Delete(List<long> ids);
    }
}
