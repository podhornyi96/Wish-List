﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Objects.Common;
using BL.Objects.Lists.Extensions;
using BL.Objects.Lists.Product;
using BL.Objects.Product;
using BL.Objects.Requests;
using BL.Objects.Stores;
using BL.Objects.Stores.Extensions;
using BL.Services.Interfaces;
using Dapper;
using DAL.Implementations;
using DAL.Interfaces;
using ShopifyRest.Objects.Common;
using ShopifyRest.Objects.Products;
using ShopifyRest.Services.Implementation;

namespace BL.Services.Implementations
{
    public enum ProductListSearchType
    {
        ByIds = 1,
        ByEventList = 2,
        AllByUser = 3
    }

    public class ProductListService : IProductListService
    {
        private readonly IProductListRepository _productListRepository;
        private readonly IStoreService _storeService;

        public ProductListService(IProductListRepository productListRepository, IStoreService storeService)
        {
            _productListRepository = productListRepository;
            _storeService = storeService;
        }

        public ProductList GetById(long id)
        {
            return GetByIds(new List<long>() { id }).FirstOrDefault();
        }

        public List<ProductList> GetByIds(List<long> ids)
        {
            return
                FillProducts(_productListRepository.Get(
                    new { SearchType = ProductListSearchType.ByIds, IDs = ids.ToTvpLongList().AsTableValuedParameter() }).Data);
        }

        public SearchResponse<ProductList> Search(ProductListSearchRequest request)
        {
            return FillProducts(_productListRepository.Get(request.ToDbRequest()));
        }

        public long Modify(ProductList productList)
        {
            return _productListRepository.Modify(productList);
        }

        public void Delete(long id)
        {
            Delete(new List<long>() { id });
        }

        public void Delete(List<long> ids)
        {
            _productListRepository.Delete(new { IDs = ids.ToTvpLongList().AsTableValuedParameter() });
        }

        private List<ProductList> FillProducts(List<ProductList> productLists)
        {
            var storeIds = productLists.Select(x => x.StoreId).ToList();

            var stores = _storeService.GetByIds(storeIds).ToDictionary(x => x.Id.Value, x => x);

            var productIdsByStore = StoreHelper.GetProductIdsByStore(productLists, stores);

            var allProducts = StoreHelper.GetProductsByStores(productIdsByStore, stores);

            var allProductsDict = allProducts.ToDictionary(x => x.Id, x => x);

            foreach (var productList in productLists)
            {
                foreach (var productItem in productList.ProductItems)
                {
                    if (allProductsDict.ContainsKey(productItem.ProductId))
                        productItem.Product = allProductsDict[productItem.ProductId];
                }
            }

            return productLists;
        }

        private SearchResponse<ProductList> FillProducts(SearchResponse<ProductList> response)
        {
            response.Data = FillProducts(response.Data);

            return response;
        }

    }
}
