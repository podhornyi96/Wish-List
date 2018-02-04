using System.Collections.Generic;
using ShopifyRest.Objects.Address;
using ShopifyRest.Objects.Common;

namespace ShopifyRest.Services.Implementation
{
    public class ShopifyAddressService : ShopifyBaseService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShopifyAddressService"/> class.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public ShopifyAddressService(ShopifySettings settings) : base(settings, "/admin/customers/addresses.json")
        {
            Settings = settings;
        }

        /// <summary>
        /// Retrieve details for one of a customers addresses
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="customerID">The customer identifier.</param>
        /// <returns></returns>
        public ShopifyAddress GetByID(long id, long customerID)
        {
            return base.GetByID<ShopifyAddress>(id, $"/admin/customers/{customerID}/addresses/{id}.json");
        }

        /// <summary>
        /// Retrieve all addresses for a customer
        /// </summary>
        /// <param name="customerID">The customer identifier.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public List<ShopifyAddress> GetAll(long customerID, long id = 0L)
        {
            return base.GetAll<ShopifyAddress>(id, $"/admin/customers/{customerID}/addresses.json?since_id={id}");
        }

        /// <summary>
        /// Creates a new address for a customer
        /// </summary>
        /// <param name="address">The address.</param>
        /// <param name="customerID">The customer identifier.</param>
        /// <returns></returns>
        public ShopifyAddress Create(ShopifyAddress address, long customerID)
        {
            return base.Create(address, $"/admin/customers/{customerID}/addresses.json");
        }

        /// <summary>
        /// Updates the values on an existing customer address
        /// </summary>
        /// <param name="address">The address.</param>
        /// <param name="customerID">The customer identifier.</param>
        /// <returns></returns>
        public ShopifyAddress Update(ShopifyAddress address, long customerID)
        {
            return base.Update(address, (long) address.Id, $"/admin/customers/{customerID}/addresses/{address.Id}.json");
        }

        /// <summary>
        /// Removes an address from the customers address list
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="customerID">The customer identifier.</param>
        public void Delete(long id, long customerID)
        {
            base.Delete(id, $"/admin/customers/{customerID}/addresses/{id}.json");
        }
    }
}
