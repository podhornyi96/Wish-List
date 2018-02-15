using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Objects.Lists.Event;
using BL.Objects.Lists.Product;
using BL.Objects.Product;
using BL.Objects.Requests;
using BL.Services.Implementations;
using ShopifyRest.Objects.Common;
using ShopifyRest.Services.Implementation;

namespace Test
{
    class Program
    {

        static void Main(string[] args)
        {
            var settings = new ShopifySettings("vlad-p.myshopify.com", "8d89b324eab8a6068b28f3a632f5db4d");
            var serv = new ShopifyProductService(settings);
            //var webhookServ = new ShopifyWebhookService(settings);

            //var hooks = webhookServ.GetAll();

            //var prods = serv.GetAll();

            var evListServ = new EventListService();
            var productListServ = new ProductListService();

            productListServ.Modify(new ProductList()
            {
                Title = "Prod list XXX",
                OwnerId = "395321376810",
                StoreId = 6
            });
            productListServ.Modify(new ProductList()
            {
                Title = "Prod list XXX",
                OwnerId = "395321376810",
                StoreId = 6
            });
            productListServ.Modify(new ProductList()
            {
                Title = "Prod list XXX",
                OwnerId = "395321376810",
                StoreId = 6
            });
            productListServ.Modify(new ProductList()
            {
                Title = "Prod list XXX",
                OwnerId = "395321376810",
                StoreId = 6
            });
            productListServ.Modify(new ProductList()
            {
                Title = "Prod list XXX",
                OwnerId = "395321376810",
                StoreId = 6
            });

            //var res = evListServ.Search(new EventListSearchRequest()
            //{
            //    SearchType = 2,
            //    Skip = 0,
            //    Top = 10,
            //    Title = "gfdfgdfg3434tdsf"
            //});

            var prodLists = productListServ.Search(new ProductListSearchRequest
            {
                Skip = 0,
                Top = 10
            });

            var gfdg = 2;
        }
    }
}
