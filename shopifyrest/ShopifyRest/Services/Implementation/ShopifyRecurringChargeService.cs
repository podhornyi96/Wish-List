using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using ShopifyRest.Objects.Charges;
using ShopifyRest.Objects.Common;

namespace ShopifyRest.Services.Implementation
{
    public class ShopifyRecurringChargeService : ShopifyBaseService
    {
        public ShopifyRecurringChargeService(ShopifySettings settings, string url = "/admin/recurring_application_charges") : base(settings, url) {}

        #region Public, non-static methods

        /// <summary>
        /// Creates the specified charge.
        /// </summary>
        /// <param name="charge">The charge.</param>
        /// <returns></returns>
        public ShopifyRecurringCharge Create(ShopifyRecurringCharge charge)
        {
            return Post<ShopifyRecurringCharge, ShopifyRecurringCharge>("/admin/recurring_application_charges.json", charge);
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="fields">The fields.</param>
        /// <returns></returns>
        public ShopifyRecurringCharge Get(long id, string fields = null)
        {
            var url = $"/admin/recurring_application_charges/{id}.json";

            if (string.IsNullOrEmpty(fields) == false)
            {
                url = $"{url}?fields={fields}";
            }

            return Get<ShopifyRecurringCharge>(url).FirstOrDefault();
        }

        /// <summary>
        /// Activates the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public void Activate(long id)
        {
            Post<ShopifyRecurringCharge, ShopifyRecurringCharge>($"/admin/recurring_application_charges/{id}/activate.json");
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public string Delete(long id)
        {
            return Delete($"recurring_application_charges/{id}.json");
        }

        #endregion
    }
}
