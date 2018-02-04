using System.Collections.Generic;
using ShopifyRest.Objects.Common;
using ShopifyRest.Objects.Filters;
using ShopifyRest.Objects.Orders;

namespace ShopifyRest.Services.Implementation
{
    public class ShopifyOrderService : ShopifyBaseService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShopifyOrderService"/> class.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="url">The URL.</param>
        public ShopifyOrderService(ShopifySettings settings) : base(settings, "/admin/orders.json")
        {
            Settings = settings;
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public ShopifyOrder GetByID(long id)
        {
            return base.GetByID<ShopifyOrder>(id);
        }

        /// <summary>
        /// Gets the by i ds.
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <returns></returns>
        public List<ShopifyOrder> GetByIDs(List<long> ids)
        {
            return base.GetByIDs<ShopifyOrder>(ids);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public List<ShopifyOrder> GetAll(long id = 0L)
        {
            return base.GetAll<ShopifyOrder>(id);
        }

        /// <summary>
        /// Filters the specified filter.
        /// </summary>
        /// <typeparam name="ShopifyOrder">The type of the hopify order.</typeparam>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        public List<ShopifyOrder> Filter(ShopifyOrderFilterRequest filter)
        {
            return base.Filter<List<ShopifyOrder>, ShopifyOrderFilterRequest>(filter);
        }

        /// <summary>
        /// Deletes by the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Delete(long id)
        {
            base.Delete(id);
        }

        /// <summary>
        /// Creates the specified order.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <returns></returns>
        public ShopifyOrder Create(ShopifyOrder order)
        {
            return base.Create(order);
        }

        /// <summary>
        /// Updates the specified order.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <returns></returns>
        public ShopifyOrder Update(ShopifyOrder order)
        {
            return base.Update(order, order.Id);
        }

        /// <summary>
        /// Close an order
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public ShopifyOrder Close(long id)
        {
            return Post<ShopifyOrder, ShopifyOrder>($"/admin/orders/{id}/close.json");
        }

        /// <summary>
        /// Re-open a closed Order
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public ShopifyOrder ReOpen(long id)
        {
            return Post<ShopifyOrder, ShopifyOrder>($"/admin/orders/{id}/open.json");
        }

        public ShopifyOrder Cancel(long id, ShopifyOrderCancelOptions cancelOptions)
        {
            return Post<ShopifyOrder, ShopifyOrderCancelOptions>($"/admin/orders/{id}/cancel.json", cancelOptions);
        }

    }
}
