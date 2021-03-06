﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Serializers;
using ShopifyRest.Objects.Products;

namespace ShopifyRest.Objects.Serializers
{
    public class JsonNetSerializer : IDeserializer, ISerializer
    {
        public string ContentType { get; set; }

        public string DateFormat { get; set; }

        public string Namespace { get; set; }

        public string RootElement { get; set; }

        public T Deserialize<T>(IRestResponse response)
        {
            T output = Activator.CreateInstance<T>();

            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            if (!string.IsNullOrEmpty(DateFormat))
            {
                settings.DateFormatString = DateFormat;
            }

            if (string.IsNullOrEmpty(RootElement))
            {
                try
                {
                    output = JsonConvert.DeserializeObject<T>(response.Content, settings);
                }
                catch
                {
                    output = (T)DeserializeProductsList(response);
                }
            }
            else
            {
                JToken data = JsonConvert.DeserializeObject(response.Content, settings) as JToken;

                if (data[RootElement] != null)
                {
                    output = data[RootElement].ToObject<T>();
                }
            }

            return output;
        }

        public IList<ShopifyProduct> DeserializeProductsList(IRestResponse response)
        {
            List<ShopifyProduct> output = Activator.CreateInstance<List<ShopifyProduct>>();

            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            JToken data = JsonConvert.DeserializeObject(response.Content, settings) as JToken;

            if (data["products"] != null)
            {
                output = data["products"].ToObject<List<ShopifyProduct>>();
            }
            return output;
        }

        public string Serialize(object obj)
        {
            ContentType = "application/json";

            string output = JsonConvert.SerializeObject(obj, Formatting.None, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            return output;
        }
    }
}
