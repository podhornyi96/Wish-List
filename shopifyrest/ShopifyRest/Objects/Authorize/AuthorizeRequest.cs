using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ShopifyRest.Objects.Attributes;

namespace ShopifyRest.Objects.Authorize
{
    public class AuthorizeRequest
    {
        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("client_id")]
        public string ShopifyApiKey { get; set; }
        [JsonProperty("client_secret")]
        public string ShopifySecretKey { get; set; }
    }
}
