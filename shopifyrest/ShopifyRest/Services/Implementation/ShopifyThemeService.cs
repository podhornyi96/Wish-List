using System.Collections.Generic;
using ShopifyRest.Objects.Common;
using ShopifyRest.Objects.Themes;

namespace ShopifyRest.Services.Implementation
{
    public class ShopifyThemeService : ShopifyBaseService
    {
        public ShopifyThemeService(ShopifySettings settings) : base(settings, "/admin/themes.json")
        {
            Settings = settings;
        }

        public List<ShopifyTheme> GetAll(long id = 0L)
        {
            return base.GetAll<ShopifyTheme>(id);
        }

        public ShopifyTheme GetById(long id)
        {
            return GetByID<ShopifyTheme>(id);
        }

        public List<ShopifyTheme> GetByIDs(List<long> ids)
        {
            return base.GetByIDs<ShopifyTheme>(ids);
        }

        public ShopifyTheme Create(ShopifyTheme shopifyTheme)
        {
            return base.Create(shopifyTheme);
        }

        public ShopifyTheme Update(ShopifyTheme shopifyTheme)
        {
            return base.Update(shopifyTheme, (long) shopifyTheme.Id);
        }

        public void Delete(long id)
        {
            base.Delete(id);
        }

    }
}
