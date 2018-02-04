using System.Collections.Generic;
using Newtonsoft.Json;

namespace ShopifyRest.Objects.Orders
{
    public class ShopifyLineItem
    {
        [JsonProperty("fulfillment_service")]
        public string FulfillmentService { get; set; }

        [JsonProperty("fulfillment_status")]
        public string FulfillmentStatus { get; set; }

        [JsonProperty("gift_card")]
        public bool GiftCard { get; set; }

        [JsonProperty("grams")]
        public int Grams { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("price")]
        public float Price { get; set; }

        [JsonProperty("product_id")]
        public long? ProductId { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("requires_shipping")]
        public bool RequiresShipping { get; set; }

        [JsonProperty("sku")]
        public string Sku { get; set; }

        [JsonProperty("taxable")]
        public string Taxable { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("variant_id")]
        public long? VariantId { get; set; }

        [JsonProperty("properties")]
        public List<ShopifyLineItemProperty> Properties { get; set; }

        /// <summary>
        /// The name of the product variant.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }


        public ShopifyLineItem(ShopifyLineItem item)
        {
            if (item == null)
                return;
            FulfillmentStatus = item.FulfillmentStatus ?? "";
            GiftCard = item.GiftCard;
            Grams = item.Grams;
            Id = item.Id;
            Price = item.Price;
            ProductId = item.ProductId;
            Quantity = item.Quantity;
            RequiresShipping = item.RequiresShipping;
            Sku = item.Sku;
            Taxable = item.Taxable;
            Title = item.Title;
            VariantId = item.VariantId;
        }
    }
}
