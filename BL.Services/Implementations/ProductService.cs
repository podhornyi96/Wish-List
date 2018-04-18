using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Objects.Requests;
using BL.Objects.Stores;
using BL.Services.Interfaces;
using DAL.Interfaces;
using ShopifyRest.Objects.Common;
using ShopifyRest.Objects.Filters;
using ShopifyRest.Objects.Filters.Enums;
using ShopifyRest.Objects.Products;
using ShopifyRest.Services.Implementation;

namespace BL.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IStoreService _storeService;

        public ProductService(IStoreService storeService)
        {
            _storeService = storeService;
        }

        public IEnumerable<ShopifyProduct> Search(ProductSearchRequest request)
        {
            var store = _storeService.GetById(request.StoreId);

            if (store == null || store.Options.HasFlag(StoreOptions.Disabled))
                throw new Exception("Store not found or disabled");

            var productService = new ShopifyProductService(new ShopifySettings(store.Host, store.AccessToken));

            var products = productService.Filter(new ShopifyProductFilterRequest
            {
                Title = request.Title,
                PublishedStatus = ShopifyPublishedStatus.Published,
                Page = request.Page,
                Limit = request.Limit
            });

            return products;
        }

    }
}
