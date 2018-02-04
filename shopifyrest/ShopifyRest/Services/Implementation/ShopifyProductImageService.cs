using System.Collections.Generic;
using ShopifyRest.Objects.Common;
using ShopifyRest.Objects.Filters;
using ShopifyRest.Objects.Products;

namespace ShopifyRest.Services.Implementation
{
    public class ShopifyProductImageService : ShopifyBaseService
    {
        public ShopifyProductImageService(ShopifySettings settings) : base(settings, "/admin/products/images.json")
        {
            Settings = settings;
        }

        /// <summary>
        /// Get a single product image by id on a specified product
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="productID">The product identifier.</param>
        /// <returns></returns>
        public ShopifyImage GetByID(long id, long productID)
        {
            return base.GetByID<ShopifyImage>(id, $"/admin/products/{productID}/images/{id}.json");
        }

        /// <summary>
        ///Get all product images for a product after a specified ID on a specified product
        /// </summary>
        /// <param name="productID">The product identifier.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public List<ShopifyImage> GetAll(long productID, long id = 0L)
        {
            return base.GetAll<ShopifyImage>(id, $"/admin/products/{productID}/images.json?since_id={id}");
        }

        /// <summary>
        /// Get a list of images by specified params on a specified product
        /// </summary>
        /// <typeparam name="ShopifyImage">The type of the hopify image.</typeparam>
        /// <param name="filter">The filter.</param>
        /// <param name="productID">The product identifier.</param>
        /// <returns></returns>
        public List<ShopifyImage> Filter(ShopifyProductImageFilterRequest filter, long productID)
        {
            return base.Filter<List<ShopifyImage>, ShopifyProductImageFilterRequest>(filter, $"/admin/products/{productID}/images.json");
        }

        /// <summary>
        ///Create a new product image on a specified product
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="productID">The product identifier.</param>
        /// <returns></returns>
        public ShopifyImage Create(ShopifyImage image, long productID)
        {
            return base.Create(image, $"/admin/products/{productID}/images.json");
        }

        /// <summary>
        /// Updates the specified image on a specified product
        /// </summary>
        /// <param name="image">The image.</param>
        /// <param name="productID">The product identifier.</param>
        /// <returns></returns>
        public ShopifyImage Update(ShopifyImage image, long productID)
        {
            return base.Update(image, image.Id, $"/admin/products/{productID}/images.json");
        }

        /// <summary>
        /// Deletes the specified identifier on a specified product
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="productID">The product identifier.</param>
        public void Delete(long id, long productID)
        {
            base.Delete(id, $"/admin/products/{productID}/images/{id}.json");
        }
    }
}
