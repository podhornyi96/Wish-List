using System.Collections.Generic;
using ShopifyRest.Objects.Common;
using ShopifyRest.Objects.Filters;
using ShopifyRest.Objects.Transactions;

namespace ShopifyRest.Services.Implementation
{
    public class ShopifyTransactionService : ShopifyBaseService
    {
        public ShopifyTransactionService(ShopifySettings settings) : base(settings, "/admin/orders/transactions.json")
        {
            Settings = settings;
        }

        /// <summary>
        /// Get the Representation of all money
        ///  transfers on a given order after a specified ID
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="orderID">The order identifier.</param>
        /// <returns></returns>
        public ShopifyTransaction GetByID(long id, long orderID)
        {
            return base.GetByID<ShopifyTransaction>(id, $"/admin/orders/{orderID}/transactions/{id}.json");
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="orderID">The order identifier.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public List<ShopifyTransaction> GetAll(long orderID, long id = 0L)
        {
            return base.GetAll<ShopifyTransaction>(id, $"/admin/orders/{orderID}/transactions.json?since_id={id}");
        }

        /// <summary>
        /// Filters the specified filter.
        /// </summary>
        /// <typeparam name="ShopifyTransaction">The type of the hopify transaction.</typeparam>
        /// <param name="filter">The filter.</param>
        /// <param name="orderID">The order identifier.</param>
        /// <returns></returns>
        public List<ShopifyTransaction> Filter(ShopifyTransactionFilterRequest filter, long orderID)
        {
            return base.Filter<List<ShopifyTransaction>, ShopifyTransactionFilterRequest>(filter, $"/admin/orders/{orderID}/transactions.json");
        }

        /// <summary>
        /// Capture a previously authorized order for the full amount
        /// </summary>
        /// <param name="transaction">The transaction.</param>
        /// <returns></returns>
        public ShopifyTransaction Capture(ShopifyTransaction transaction, long orderID)
        {
            return Create(transaction, $"/admin/orders/{orderID}/transactions.json");
        }

    }
}
