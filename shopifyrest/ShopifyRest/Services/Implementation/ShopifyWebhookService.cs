using System.Collections.Generic;
using ShopifyRest.Objects.Common;
using ShopifyRest.Objects.Filters;
using ShopifyRest.Objects.Webhooks;

namespace ShopifyRest.Services.Implementation
{
    public class ShopifyWebhookService : ShopifyBaseService
    {
        public ShopifyWebhookService(ShopifySettings settings) : base(settings, "/admin/webhooks.json")
        {
            Settings = settings;
        }

        /// <summary>
        /// Get a single webhook
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public ShopifyWebhook GetByID(long id)
        {
            return base.GetByID<ShopifyWebhook>(id);
        }

        /// <summary>
        /// Gets the Webhooks by ids.
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <returns></returns>
        public List<ShopifyWebhook> GetByIDs(List<long> ids)
        {
            return base.GetByIDs<ShopifyWebhook>(ids);
        }

        /// <summary>
        /// Gets all webhooks.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public List<ShopifyWebhook> GetAll(long id = 0L)
        {
            return base.GetAll<ShopifyWebhook>(id);
        }

        public List<ShopifyWebhook> Filter(ShopifyWebhookFilterRequest filter)
        {
            return base.Filter<List<ShopifyWebhook>, ShopifyWebhookFilterRequest>(filter);
        }

        /// <summary>
        /// Every webhook needs a topic and an address. 
        /// Failure to have a topic or an address will result in a 422 - Unprocessable Entity error.
        /// </summary>
        /// <param name="webhook">The webhook.</param>
        /// <returns></returns>
        public ShopifyWebhook Create(ShopifyWebhook webhook)
        {
            return base.Create(webhook);
        }

        /// <summary>
        /// Update a webhook's topic and/or address URIs.
        /// </summary>
        /// <param name="webhook">The webhook.</param>
        /// <returns></returns>
        public ShopifyWebhook Update(ShopifyWebhook webhook)
        {
            return base.Update(webhook, (long) webhook.Id);
        }

    }
}
