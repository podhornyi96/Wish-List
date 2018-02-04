using System.Collections.Generic;
using ShopifyRest.Objects.Common;
using ShopifyRest.Objects.Customers;
using ShopifyRest.Objects.Filters;

namespace ShopifyRest.Services.Implementation
{
    public class ShopifyCustomerService :ShopifyBaseService
    {
        public ShopifyCustomerService(ShopifySettings settings) : base(settings, "admin/customers.json")
        {
            Settings = settings;
        }

        /// <summary>
        ///Get a single customer by ID
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public ShopifyCustomer GetByID(long id)
        {
            return base.GetByID<ShopifyCustomer>(id);
        }

        /// <summary>
        ///Retrieve  customers of a shop by list of ids
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <returns></returns>
        public List<ShopifyCustomer> GetByIDs(List<long> ids)
        {
            return base.GetByIDs<ShopifyCustomer>(ids);
        }

        /// <summary>
        /// Retrieve all customers of a shop
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public List<ShopifyCustomer> GetAll(long id = 0L)
        {
            return base.GetAll<ShopifyCustomer>(id);
        }

        /// <summary>
        ///Delete a customer. A customer can't be deleted if they have existing orders
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Delete(long id)
        {
            base.Delete(id);
        }

        /// <summary>
        /// Creates the specified customer.
        /// </summary>
        /// <param name="customer">The customer.</param>
        /// <returns></returns>
        public ShopifyCustomer Create(ShopifyCustomer customer)
        {
            return base.Create(customer);
        }

        /// <summary>
        /// Updates the specified customer.
        /// </summary>
        /// <param name="customer">The customer.</param>
        /// <returns></returns>
        public ShopifyCustomer Update(ShopifyCustomer customer)
        {
            return base.Update(customer, (long) customer.Id);
        }

        /// <summary>
        /// Filters custumers.
        /// </summary>
        /// <typeparam name="ShopifyCustomer">The type of the hopify customer.</typeparam>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        public List<ShopifyCustomer> Filter(ShopifyCustomerFilterRequest filter)
        {
            return base.Filter<List<ShopifyCustomer>, ShopifyCustomerFilterRequest>(filter);
        }

        /// <summary>
        ///This endpoint allows you to generate and retrieve an account
        /// activation URL for a customer who is not yet enabled
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public ShopifyCustomerActivationUrl ActivationUrl(string id)
        {
            return Post<ShopifyCustomerActivationUrl, ShopifyCustomerActivationUrl>($"/admin/customers/{id}/account_activation_url.json");
        }

        /// <summary>
        /// Searches the specified customer.
        /// </summary>
        /// <param name="searchRequest">The search request.</param>
        /// <returns></returns>
        public List<ShopifyCustomer> Search(ShopiyCustomerSearchRequest searchRequest)
        {
            return Get<ShopifyCustomer>
                ($"/admin/customers/search.json?limit={searchRequest.Limit}&order={searchRequest.Order}&page={searchRequest.Page}&query={searchRequest.Query}");
        }

    }
}
