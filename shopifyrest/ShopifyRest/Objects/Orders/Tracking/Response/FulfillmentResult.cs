using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ShopifyRest.Objects.Interfaces;
using ShopifyRest.Utils;

namespace ShopifyRest.Objects.Orders.Tracking.Response
{
    public class FulfillmentResult : ICallResult
    {
        public bool IsSuccess { get; set; }
        public ShopifyFulfillment Success { get; set; }
        public List<string> Error { get; set; }

        public FulfillmentResult(string data) // FulfillmentResult
        {
            if (Json.IsJsonError(data))
            {
                IsSuccess = false;
                var j = JObject.Parse(data);
                if (!j["errors"].Children().Any())
                {
                    Error = new List<string>() {j["errors"].ToString()};
                }
                else
                {
                    Error = JsonConvert.DeserializeObject<FulfillmentErrors>(data).Errors.Order;
                }
            }
            else
            {
                Success = JsonConvert.DeserializeObject<FulfilmentResponse>(data).Fulfillment;
                IsSuccess = true;
            }
        }
    }
}
