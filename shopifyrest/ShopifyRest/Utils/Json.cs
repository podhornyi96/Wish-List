using Newtonsoft.Json.Linq;

namespace ShopifyRest.Utils
{
    public class Json
    {
        public static bool IsJsonError(string json)
        {
            var o = JObject.Parse(json);
            return o.First.Path.Equals("errors");
        }
    }
}
