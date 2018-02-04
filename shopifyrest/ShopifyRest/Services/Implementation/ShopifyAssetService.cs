using System.Collections.Generic;
using ShopifyRest.Objects.Assets;
using ShopifyRest.Objects.Common;
using ShopifyRest.Objects.Filters;

namespace ShopifyRest.Services.Implementation
{
    public class ShopifyAssetService : ShopifyBaseService
    {
        public ShopifyAssetService(ShopifySettings settings) : base(settings, "/admin/themes/assets.json")
        {
            Settings = settings;
        }

        public List<ShopifyAsset> Get(long themeId, string key = null)
        {
            return Get<ShopifyAsset>($"/admin/themes/{themeId}/assets.json" + (key != null ? $"?asset[key]={key}&theme_id={themeId}" : ""));
        }

        public ShopifyAsset Update(ShopifyAsset asss)
        {
            return base.Update(asss, asss.ThemeId, $"/admin/themes/{asss.ThemeId}/assets.json");
        }

        /// <summary>
        /// Filters the specified filter.
        /// </summary>
        /// <typeparam name="TShopifyAsset">The type of the shopify asset.</typeparam>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        public List<TShopifyAsset> Filter<TShopifyAsset>(ShopifyAssetsFilterRequest filter)
        {
            return base.Filter<List<TShopifyAsset>, ShopifyAssetsFilterRequest>(filter);
        }

        public void Delete(long id)
        {
            base.Delete(id);
        }

    }
}
