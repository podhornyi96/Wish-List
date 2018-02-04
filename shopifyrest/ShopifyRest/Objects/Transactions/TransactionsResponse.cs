using System.Collections.Generic;
using Newtonsoft.Json;

namespace ShopifyRest.Objects.Transactions
{
    public class TransactionsResponse
    {
        [JsonProperty("transactions")]
        public List<ShopifyTransaction> Transactions { get; set; }
    }
}
