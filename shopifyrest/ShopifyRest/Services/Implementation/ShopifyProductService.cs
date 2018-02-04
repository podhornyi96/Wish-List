using System.Collections.Generic;
using ShopifyRest.Objects.Common;
using ShopifyRest.Objects.Filters;
using ShopifyRest.Objects.Products;

namespace ShopifyRest.Services.Implementation
{
    public class ShopifyProductService : ShopifyBaseService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShopifyProductService"/> class.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public ShopifyProductService(ShopifySettings settings) : base(settings, "admin/products.json")
        {
            Settings = settings;
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public ShopifyProduct GetByID(long id) 
        {
            return base.GetByID<ShopifyProduct>(id);
        }

        /// <summary>
        /// Gets the by i ds.
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <returns></returns>
        public List<ShopifyProduct> GetByIDs(List<long> ids)
        {
            return base.GetByIDs<ShopifyProduct>(ids);
        }

        /// <summary>
        /// Creates the product.
        /// </summary>
        /// <param name="prod">The product.</param>
        /// <returns></returns>
        public ShopifyProduct Create(ShopifyProduct prod)
        {
            return base.Create(prod);
        }

        public ShopifyProduct Update(ShopifyProduct prop)
        {
            return base.Update(prop, prop.Id);
        }

        /// <summary>
        /// Deletes the product.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Delete(long id)
        {
            base.Delete(id);
        }

        /// <summary>
        /// Get a list of specific products.
        /// </summary>
        /// <typeparam name="ShopifyProduct">The type of the hopify product.</typeparam>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        public List<ShopifyProduct> Filter(ShopifyProductFilterRequest filter)
        {
            return base.Filter<List<ShopifyProduct>, ShopifyProductFilterRequest>(filter);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public List<ShopifyProduct> GetAll(long id = 0L)
        {
            return base.GetAll<ShopifyProduct>(id);
        }
    }
}
