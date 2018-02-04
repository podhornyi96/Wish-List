using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Objects.Common;
using BL.Objects.Lists.Product;
using BL.Objects.Product;
using BL.Objects.Product.Extensions;
using Dapper;
using DAL.Interfaces;

namespace DAL.Implementations
{
    public class ProductListRepository : IProductListRepository
    {
        public SearchResponse<ProductList> Get(object obj)
        {
            using (var multi = Repository.GetConnection().QueryMultiple("dbo.ProductListGet", obj, commandTimeout: int.MaxValue, commandType: CommandType.StoredProcedure))
            {
                var productLists = multi.Read<ProductList>().ToDictionary(x => x.Id, x => x); ;

                multi.Read<long, ProductItem, int>((productListId, productItem) =>
                {
                    if (!productLists.ContainsKey(productListId))
                        return 0;

                    productLists[productListId].ProductItems.Add(productItem);

                    return 0;
                }, splitOn: "ProdListId,ProductListId");

                var totalRows = multi.Read<int>().FirstOrDefault();

                return new SearchResponse<ProductList>
                {
                    Data = productLists.Values.ToList(),
                    TotalRows = totalRows
                };
            }
        }

        public long Modify(ProductList productList)
        {
            return Repository.GetConnection().Query<long>("dbo.ProductListModify", new
            {
                Id = productList.Id,
                OwnerId = productList.OwnerId,
                StoreId = productList.StoreId,
                EventListId = productList.EventListId,
                Title = productList.Title,
                Products = productList.ProductItems.ToTvp().AsTableValuedParameter()
            }, commandType: CommandType.StoredProcedure, commandTimeout: int.MaxValue).First();
        }

        public void Delete(object obj)
        {
            Repository.GetConnection()
                .Query<bool>("dbo.ProductListDelete", obj, commandType: CommandType.StoredProcedure, commandTimeout: int.MaxValue);
        }
    }
}
