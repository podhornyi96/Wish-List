using System.Collections.Generic;
using ShopifyRest.Objects.Common;
using ShopifyRest.Objects.Filters;
using ShopifyRest.Objects.Pages;

namespace ShopifyRest.Services.Implementation
{
    public class ShopifyPageService : ShopifyBaseService
    {
        public ShopifyPageService(ShopifySettings settings) : base(settings, "/admin/pages.json")
        {
            Settings = settings;
        }

        /// <summary>
        /// Get a single page by its ID
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public ShopifyPage GetByID(long id)
        {
            return base.GetByID<ShopifyPage>(id);
        }

        /// <summary>
        /// Get a list of all pages
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public List<ShopifyPage> GetAll(long id = 0L)
        {
            return base.GetAll<ShopifyPage>(id);
        }

        /// <summary>
        /// Get a list of pages by specified params
        /// </summary>
        /// <typeparam name="ShopifyPage">The type of the hopify page.</typeparam>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        public List<ShopifyPage> Filter(ShopifyPageFilterRequest filter)
        {
            return base.Filter<List<ShopifyPage>, ShopifyPageFilterRequest>(filter);
        }

        /// <summary>
        /// Deletes page by the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Delete(long id)
        {
            base.Delete(id);
        }

        /// <summary>
        ///Create a new page
        /// </summary>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        public ShopifyPage Create(ShopifyPage page)
        {
            return base.Create(page);
        }

        /// <summary>
        ///Update a page
        /// </summary>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        public ShopifyPage Update(ShopifyPage page)
        {
            return base.Update(page, (long) page.Id);
        }


    }
}
