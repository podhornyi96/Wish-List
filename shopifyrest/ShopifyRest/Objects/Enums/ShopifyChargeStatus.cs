using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ShopifyRest.Objects.Converters;

namespace ShopifyRest.Objects.Enums
{
    [JsonConverter(typeof(NullableEnumConverter<ShopifyChargeStatus>))]
    public enum ShopifyChargeStatus
    {
        /// <summary>
        /// The charge is pending and has not been accepted or declined by the user.
        /// </summary>
        [EnumMember(Value = "pending")]
        Pending,

        /// <summary>
        /// The charge has been accepted by the user and can be activated.
        /// </summary>
        [EnumMember(Value = "accepted")]
        Accepted,

        /// <summary>
        /// The charge has been accepted and activated.
        /// </summary>
        [EnumMember(Value = "active")]
        Active,

        /// <summary>
        /// The charge has been cancelled.
        /// </summary>
        [EnumMember(Value = "cancelled")]
        Cancelled,

        /// <summary>
        /// The charge has been declined by the user and cannot be activated.
        /// </summary>
        [EnumMember(Value = "declined")]
        Declined,

        /// <summary>
        /// The charge has expired.
        /// </summary>
        [EnumMember(Value = "expired")]
        Expired,

    }
}
