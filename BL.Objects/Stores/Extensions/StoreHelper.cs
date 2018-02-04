using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Objects.Lists.Product;
using ShopifyRest.Objects.Common;
using ShopifyRest.Objects.Products;
using ShopifyRest.Services.Implementation;

namespace BL.Objects.Stores.Extensions
{
    public static class StoreHelper
    {
        public static Dictionary<long, List<long>> GetProductIdsByStore(List<ProductList> productLists, Dictionary<long, Store> stores)
        {
            var productIdsByStore = new Dictionary<long, HashSet<long>>();

            foreach (var productList in productLists)
            {
                if (!stores.ContainsKey(productList.StoreId))
                    continue;

                if (!productIdsByStore.ContainsKey(productList.StoreId))
                    productIdsByStore[productList.StoreId] = new HashSet<long>();

                productIdsByStore[productList.StoreId].UnionWith(productList.ProductItems.Select(x => x.ProductId));
            }

            return productIdsByStore.ToDictionary(x => x.Key, x => x.Value.ToList());
        }

        public static List<ShopifyProduct> GetProductsByStores(Dictionary<long, List<long>> productIdsByStore, Dictionary<long, Store> stores)
        {
            var allProducts = new List<ShopifyProduct>();

            foreach (var storeProduct in productIdsByStore)
            {
                if (!stores.ContainsKey(storeProduct.Key))
                    continue;

                var store = stores[storeProduct.Key];

                var productService = new ShopifyProductService(new ShopifySettings(store.Host, store.AccessToken));

                allProducts.AddRange(productService.GetByIDs(storeProduct.Value));
            }

            return allProducts;
        }
    }
}
