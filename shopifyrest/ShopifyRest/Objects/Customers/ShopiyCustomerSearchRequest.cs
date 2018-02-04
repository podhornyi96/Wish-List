namespace ShopifyRest.Objects.Customers
{
    public class ShopiyCustomerSearchRequest
    {
        public string Order { get; set; }

        public string Query { get; set; }

        public int Page { get; set; }

        public int Limit { get; set; }
    }
}
