using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using BL.Objects.Common;
using BL.Objects.Stores;
using BL.Services.Implementations;
using BL.Services.Interfaces;
using ShopifyRest.Objects.Common;
using ShopifyRest.Objects.Enums;
using ShopifyRest.Objects.Shop;
using ShopifyRest.Objects.Webhooks;
using ShopifyRest.Services.Implementation;

namespace WishList.API.Controllers
{
    public class StoreController : ApiController
    {
        private readonly IStoreService _storeService;

        public StoreController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        [Route("{id:long}")]
        [HttpGet]
        public IHttpActionResult GetById(long id)
        {
            return Ok(_storeService.GetById(id));
        }

        [Route("store")]
        [HttpGet]
        public IHttpActionResult GetByHost([FromUri] string shop)
        {
            return Ok(_storeService.GetByHost(shop));
        }

        [Route("install")]
        [HttpGet]
        public IHttpActionResult Install(string shop)
        {
            var nonce = Guid.NewGuid().ToString();

            var store = _storeService.GetByHost(shop);

            if(store != null && !store.Options.HasFlag(StoreOptions.Disabled))
                return BadRequest("Application already installed");

            var authUrl = ShopifyAuthorizationService.BuildAuthorizationUrl(new List<ShopifyAuthorizationScope>()
                {
                    ShopifyAuthorizationScope.ReadProducts,
                    ShopifyAuthorizationScope.ReadCustomers
                },
                shop, SystemSettings.ApiKey, SystemSettings.RedirectUrl, nonce);

            if (store == null)
                store = new Store()
                {
                    Host = shop,
                    Options = StoreOptions.Disabled
                };

            store.Nonce = nonce;

            _storeService.Update(store);

            return Redirect(authUrl);
        }

        [Route("connect")]
        [HttpGet]
        public IHttpActionResult Connect(string code, string shop, string hmac, string state)
        {
            if (!ShopifyAuthorizationService.IsValidMyShopifyUrl(shop))
                return BadRequest();

            var queryString = HttpUtility.ParseQueryString(Request.RequestUri.Query);

            if (!ShopifyAuthorizationService.IsAuthenticRequest(queryString, SystemSettings.ApiSecret))
                return BadRequest();

            var store = _storeService.GetByHost(shop);

            if (store.Nonce != state)
                return BadRequest();

            var authService = new ShopifyAuthorizationService(new ShopifySettings()
            {
                AuthenticationType = AuthenticationType.AccessToken,
                HostName = shop
            });

            var accessToken = authService.Authorize(code, SystemSettings.ApiKey, SystemSettings.ApiSecret);

            if (string.IsNullOrEmpty(accessToken))
                return BadRequest();

            store.AccessToken = accessToken;
            store.Code = code;
            store.Options &= ~StoreOptions.Disabled;

            _storeService.Update(store);

            var webhookService = new ShopifyWebhookService(new ShopifySettings(shop, accessToken));

            webhookService.Create(new ShopifyWebhook()
            {
                Topic = ShopifyWebhookTopic.AppUninstalled,
                Address = SystemSettings.UninstallUrl,
                Format = "json"
            });

            return Redirect(ShopifyAuthorizationService.BuildShopUri(shop));
        }

        [HttpPost]
        [Route("uninstall")]
        public IHttpActionResult Uninstall(ShopifyShop shop)
        {
            var store = _storeService.GetByHost(shop.Domain);

            if (store == null)
                return BadRequest("Store not found.");

            store.Options |= StoreOptions.Disabled;

            _storeService.Update(store);

            return Redirect(ShopifyAuthorizationService.BuildShopUri(shop.Domain));
        }

    }
}
