using Newtonsoft.Json;

namespace ShopifyRest.Objects.Orders
{
    public class ShopifyPaymentDetails
    {
        [JsonProperty("credit_card_bin")]
        public string CreditCardBin { get; set; }

        [JsonProperty("avs_result_code")]
        public string AvsResultCode { get; set; }

        [JsonProperty("cvv_result_code")]
        public string CvvResultCode { get; set; }

        [JsonProperty("credit_card_number")]
        public string CreditCardNumber { get; set; }

        [JsonProperty("credit_card_company")]
        public string CreditCardCompany { get; set; }
    }
}
