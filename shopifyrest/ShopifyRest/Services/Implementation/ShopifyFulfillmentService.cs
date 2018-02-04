using System.Collections.Generic;
using ShopifyRest.Objects.Common;
using ShopifyRest.Objects.Filters;
using ShopifyRest.Objects.Orders.Tracking;

namespace ShopifyRest.Services.Implementation
{
    public class ShopifyFulfillmentService : ShopifyBaseService
    {
        public ShopifyFulfillmentService(ShopifySettings settings) : base(settings, "/admin/orders/fulfillments.json")
        {
            Settings = settings;
        }

        /// <summary>
        /// Gets the fulfillment by Fulfillment id 
        /// and Order id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="orderID">The order identifier.</param>
        /// <returns></returns>
        public ShopifyFulfillment GetByID(long id, long orderID)
        {
            return base.GetByID<ShopifyFulfillment>(id, $"/admin/orders/{orderID}/fulfillments/{id}.json");
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="orderID">The order identifier.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public List<ShopifyFulfillment> GetAll(long orderID, long id = 0L)
        {
            return base.GetAll<ShopifyFulfillment>(id, $"/admin/orders/{orderID}/fulfillments/count.json?since_id={id}");
        }

        /// <summary>
        /// Creates the specified fulfillment.
        /// </summary>
        /// <param name="fulfillment">The fulfillment.</param>
        /// <param name="orderID">The order identifier.</param>
        /// <returns></returns>
        public ShopifyFulfillment Create(ShopifyFulfillment fulfillment, long orderID)
        {
            return base.Create(fulfillment, $"/admin/orders/{orderID}/fulfillments.json");
        }

        /// <summary>
        /// Updates the specified fulfillment.
        /// </summary>
        /// <param name="fulfillment">The fulfillment.</param>
        /// <param name="orderID">The order identifier.</param>
        /// <returns></returns>
        public ShopifyFulfillment Update(ShopifyFulfillment fulfillment, long orderID)
        {
            return base.Update(fulfillment, fulfillment.Id, $"/admin/orders/{orderID}/fulfillments/{fulfillment.Id}.json");
        }

        /// <summary>
        /// Complete a fulfillment.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="orderID">The order identifier.</param>
        /// <returns></returns>
        public ShopifyFulfillment Complete(long id, long orderID)
        {
            return base.Post<ShopifyFulfillment, ShopifyFulfillment>($"/admin/orders/{orderID}/fulfillments/{id}/complete.json");
        }

        /// <summary>
        /// Transition a fulfillment 
        /// from pending to open.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="orderID">The order identifier.</param>
        /// <returns></returns>
        public ShopifyFulfillment Open(long id, long orderID)
        {
            return Post<ShopifyFulfillment, ShopifyFulfillment>($"/admin/orders/{orderID}/fulfillments/{id}/open.json");
        }

        /// <summary>
        /// Cancels the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="orderID">The order identifier.</param>
        /// <returns></returns>
        public ShopifyFulfillment Cancel(long id, long orderID)
        {
            return Post<ShopifyFulfillment, ShopifyFulfillment>($"/admin/orders/{orderID}/fulfillments/{id}/cancel.json");
        }

        /// <summary>
        /// Filters the specified filter.
        /// </summary>
        /// <typeparam name="ShopifyFulfillment">The type of the hopify fulfillment.</typeparam>
        /// <param name="filter">The filter.</param>
        /// <param name="orderID">The order identifier.</param>
        /// <returns></returns>
        public List<ShopifyFulfillment> Filter(ShopifyFulfillmentFilterRequest filter, long orderID)
        {
            return base.Filter<List<ShopifyFulfillment>, ShopifyFulfillmentFilterRequest>(filter, $"/admin/orders/{orderID}/fulfillments.json");
        }
    }
}
