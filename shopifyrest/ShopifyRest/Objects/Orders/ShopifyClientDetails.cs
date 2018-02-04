using Newtonsoft.Json;

namespace ShopifyRest.Objects.Orders
{
    public class ShopifyClientDetails
    {
        [JsonProperty("browser_ip")]
        public string BrowserIp { get; set; }

        [JsonProperty("accept_language")]
        public object AcceptLanguage { get; set; }

        [JsonProperty("user_agent")]
        public string UserAgent { get; set; }

        [JsonProperty("session_hash")]
        public object SessionHash { get; set; }

        [JsonProperty("browser_width")]
        public object BrowserWidth { get; set; }

        [JsonProperty("browser_height")]
        public object BrowserHeight { get; set; }
    }
}
