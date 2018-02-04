using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ShopifyRest.Objects.Converters;

namespace ShopifyRest.Objects.Themes
{
    [JsonConverter(typeof(NullableEnumConverter<ShopifyThemeRole>))]
    public enum ShopifyThemeRole
    {
        /// <summary>
        /// This theme can be seen by customers when visiting the shop in a desktop browser.
        /// </summary>
        [EnumMember(Value = "main")]
        Main,

        /// <summary>
        /// This theme can be seen by customers when visiting the shop in a mobile browser.
        /// </summary>
        [EnumMember(Value = "mobile")]
        Mobile,

        /// <summary>
        /// This theme cannot currently be seen by customers.
        /// </summary>
        [EnumMember(Value = "unpublished")]
        Unpublished
    }
}
