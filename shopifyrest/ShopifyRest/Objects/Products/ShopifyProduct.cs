// ***********************************************************************
// Assembly         :  .Marketplaces
// Author           : Alexander.K
// Created          : 09-02-2015
//
// Last Modified By : Alexander.K
// Last Modified On : 09-02-2015
// ***********************************************************************
// <copyright file="ShopifyProduct.cs" company=" ">
//     Copyright ©   2015
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
//using GiftRegistry.BL.Objects.GiftRegistry;
using Newtonsoft.Json;
using ShopifyRest.Objects.Attributes;
using ShopifyRest.Objects.Interfaces;
using ShopifyRest.Objects.Products.Variants;


namespace ShopifyRest.Objects.Products
{
    /// <summary>
    /// Class ShopifyProduct.
    /// </summary>
    [ShopifyRootObject("product")]
    public class ShopifyProduct : IShopifyBaseObject, IItem
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("handle")]
        public string Handle { get; set; }

        [JsonProperty("variants")]
        public List<ShopifyVariant> Variants { get; set; }

        [JsonProperty("vendor")]
        public string Vendor { get; set; }

        [JsonProperty("product_type")]
        public string ProductType { get; set; }
        [JsonProperty("published_at")]
        public DateTime? PublishedAt { get; set; }

        [JsonProperty("body_html")]
        public string Body { get; set; }

        [JsonProperty("images")]
        public List<ShopifyImage> Images { get; set; }

        [JsonProperty("tags")]
        public string Tags { get; set; }

        [JsonProperty("published_scope")]
        public string PublishedScope { get; set; } = "";
    }

    [ShopifyRootObject("image")]
    public class ShopifyImage : IShopifyBaseObject
    {
        [JsonProperty("src")]
        public string Src { get; set; }

        [JsonProperty("product_id")]
        public long ProductId { get; set; }

        [JsonProperty("variant_ids")]
        public List<long> Variants { get; set; } 

        public ShopifyImage(string url)
        {
            Src = url;
        }

        public long Id { get; set; }
    }
}