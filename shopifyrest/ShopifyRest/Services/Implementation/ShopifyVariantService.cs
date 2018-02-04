using System.Collections.Generic;
using ShopifyRest.Objects.Common;
using ShopifyRest.Objects.Filters;
using ShopifyRest.Objects.Products.Variants;

namespace ShopifyRest.Services.Implementation
{
    public class ShopifyVariantService : ShopifyBaseService 
    {
        public ShopifyVariantService(ShopifySettings settings) : base(settings, "/admin/variants.json")
        {
            Settings = settings;
        }

        /// <summary>
        /// Gets the Variants by identifier on the specified product
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public ShopifyVariant GetByID(long id)
        {
            return base.GetByID<ShopifyVariant>(id);
        }

        /// <summary>
        /// Get a list of product variants on the specified product
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public List<ShopifyVariant> GetAll(long productID, long id = 0L)
        {
            return base.GetAll<ShopifyVariant>(id, $"/admin/products/{id}/variants.json?since_id={id}");
        }

        /// <summary>
        /// Get a list of pages by specified params on the specified product
        /// </summary>
        /// <typeparam name="ShopifyVariant">The type of the hopify variant.</typeparam>
        /// <param name="filter">The filter.</param>
        /// <param name="productID">The product identifier.</param>
        /// <returns></returns>
        public List<ShopifyVariant> Filter(ShopifyProductVariantFilterRequest filter, long productID)
        {
            return base.Filter<List<ShopifyVariant>, ShopifyProductVariantFilterRequest>(filter, $"/admin/products/{productID}/variants.json");
        }

        /// <summary>
        /// Creates the specified variant on the specified product
        /// </summary>
        /// <param name="variant">The variant.</param>
        /// <param name="productID">The product identifier.</param>
        /// <returns></returns>
        public ShopifyVariant Create(ShopifyVariant variant, long productID)
        {
            return base.Create(variant, $"/admin/products/{productID}/variants.json");
        }

        /// <summary>
        /// Updates the specified variant on the specified product
        /// </summary>
        /// <param name="variant">The variant.</param>
        /// <returns></returns>
        public ShopifyVariant Update(ShopifyVariant variant)
        {
            return base.Update(variant, variant.Id);
        }

        /// <summary>
        /// Deletes the specified product by the identifier on the specified product
        /// </summary>
        /// <param name="productID">The product identifier.</param>
        /// <param name="variantID">The variant identifier.</param>
        public void Delete(long productID, long variantID)
        {
           base.Delete(productID , $"/admin/products/{productID}/variants/{variantID}.json");
        }


    }
}
