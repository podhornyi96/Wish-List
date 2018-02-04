using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ShopifyRest.Objects.Attributes;
using ShopifyRest.Objects.Common;

namespace ShopifyRest.Objects.Shop
{
    [ShopifyRootObject("shop")]
    public class ShopifyShop : ShopifyObject, IShopifyBaseObject
    {
        public long Id { get; set; }
        [JsonProperty("address1")]
        public string Address1 { get; set; }
        [JsonProperty("address2")]
        public string Address2 { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("country_code")]
        public string CountryCode { get; set; }
        [JsonProperty("country_name")]
        public string CountryName { get; set; }
        [JsonProperty("created_at")]
        public DateTime CreateAt { get; set; }
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
        [JsonProperty("customer_email")]
        public string CustomerEmail { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("domain")]
        public string Domain { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        //TODO: add all fields
    }
}
