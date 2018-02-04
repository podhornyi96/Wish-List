using System.Runtime.Serialization;
using Newtonsoft.Json;
using ShopifyRest.Objects.Converters;

namespace ShopifyRest.Objects.Filters.Enums
{
    /// <summary>
    /// The status of a fulfillment.
    /// </summary>
    [JsonConverter(typeof(NullableEnumConverter<ShopifyFulfillmentStatus>))]
    public enum ShopifyFulfillmentStatus
    {
        /// <summary>
        /// Every line item in the order has been fulfilled.
        /// </summary>
        [EnumMember(Value = "fulfilled")]
        Fulfilled,

        /// <summary>
        /// None of the line items in the order have been fulfilled.
        /// </summary>
        [EnumMember(Value = "none")]
        None,

        /// <summary>
        /// At least one line item in the order has been fulfilled.
        /// </summary>
        [EnumMember(Value = "partial")]
        Partial
    }
}
