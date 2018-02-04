using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ShopifyRest.Objects.Authorize
{
    public class AuthorizeResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
    }
}
