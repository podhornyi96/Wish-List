using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using NLog;
using RestSharp;
using RestSharp.Authenticators;
using ShopifyRest.Objects.Common;

namespace ShopifyRest.Utils
{
    public enum RequestState
    {
        Ok,
        Repeat,
        Fail
    }
    public class Net
    {
        public static bool ApiWait { get; set; }
        private static readonly object _lock = new object();
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Waits until application could make another response.
        /// </summary>
        public static void WaitLimit()
        {
            lock (_lock)
            {
                if (!ApiWait)
                    return;

                ApiWait = false;
            }

            Thread.Sleep(1000);
        }

        private static RestClient GetClient(ShopifySettings shopifySettings)
        {
            if (shopifySettings.AuthenticationType == AuthenticationType.AccessToken)
            {
                var client = new RestClient($"https://{shopifySettings.HostName}");
                client.AddDefaultHeader("X-Shopify-Access-Token", shopifySettings.AccessToken);
                return client;
            }
            else
            {
                return new RestClient($"https://{shopifySettings.HostName}") { Authenticator = new HttpBasicAuthenticator(shopifySettings.ApiKey, shopifySettings.Password) };
            }
        }

        /// <summary>
        /// Makes the get request to shopify API with specified settings and URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="shopifySettings">The shopify settings.</param>
        /// <returns>JSON response</returns>
        public static string MakeGet(string url, ShopifySettings shopifySettings)
        {
            try
            {
                WaitLimit();

                var client = GetClient(shopifySettings);

                var request = new RestRequest(url, Method.GET);
                var response = client.Execute(request);

                var statusCode = response.StatusCode;

                var res = CheckHeader(response);

                return res == RequestState.Repeat ? MakeGet(url, shopifySettings) : response.Content;
            }
            catch (Exception e)
            {

                LogHelper.LogEvent(new LogEventRequest(_logger)
                {
                    Exception = e,
                    LogLevel = LogLevel.Error,
                    Method = MethodBase.GetCurrentMethod(),
                    Values = new List<object>() { url, shopifySettings }
                });

                return string.Empty;
            }
        }

        /// <summary>
        /// Makes the delete request with specified settings and URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="shopifySettings">The shopify settings.</param>
        /// <returns>JSON response</returns>
        public static string MakeDelete(string url, ShopifySettings shopifySettings)
        {
            try
            {
                WaitLimit();

                var client = GetClient(shopifySettings);

                var request = new RestRequest(url, Method.DELETE);
                var response = client.Execute(request);

                var res = CheckHeader(response);

                return res == RequestState.Repeat ? MakeDelete(url, shopifySettings) : response.Content;
            }
            catch (Exception e)
            {
                LogHelper.LogEvent(new LogEventRequest(_logger)
                {
                    Exception = e,
                    LogLevel = LogLevel.Error,
                    Method = MethodBase.GetCurrentMethod(),
                    Values = new List<object>() { url, shopifySettings }
                });

                return string.Empty;
            }
        }

        /// <summary>
        /// Checks the header.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <returns>Returns request state</returns>
        public static RequestState CheckHeader(IRestResponse response)
        {
            if (response.Content.Contains("Exceeded 2 calls per second for api client."))
            {
                lock (_lock)
                {
                    ApiWait = true;
                    return RequestState.Repeat;
                }
            }

            try
            {
                var count = response.Headers.ToList()
                    .Find(x => x.Name == "HTTP_X_SHOPIFY_SHOP_API_CALL_LIMIT")
                    .Value.ToString().Split('/');

                if (Convert.ToInt32(count[0]) >= (Convert.ToInt32(count[1]) - 1))
                {
                    lock (_lock)
                    {
                        ApiWait = true;
                        return RequestState.Ok;
                    }
                }


            }
            catch (Exception e)
            {
                if (response.StatusCode.ToString() == "429")
                {
                    lock (_lock)
                    {
                        ApiWait = true;
                    }

                    return RequestState.Repeat;
                }


                LogHelper.LogEvent(new LogEventRequest(_logger)
                {
                    Exception = e,
                    LogLevel = LogLevel.Error,
                    Method = MethodBase.GetCurrentMethod(),
                    Values = new List<object>() { response }
                });



                return RequestState.Fail;
            }

            return RequestState.Ok;

        }

        /// <summary>
        /// Makes the PUT request to shopify API with specified settings, data to update and URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="data">The data.</param>
        /// <param name="shopifySettings">The shopify settings.</param>
        /// <returns>JSON response</returns>
        public static string MakePut(string url, object data, ShopifySettings shopifySettings)
        {
            try
            {
                WaitLimit();

                var client = GetClient(shopifySettings);

                var request = new RestRequest(url, Method.PUT);
                request.RequestFormat = DataFormat.Json;
                request.JsonSerializer = new RestSharpJsonNetSerializer();
                request.AddBody(data);
                var response = client.Execute(request);

                var res = CheckHeader(response);

                if (res == RequestState.Repeat)
                    return MakePut(url, data, shopifySettings);

                return response.Content;
            }
            catch (Exception e)
            {
                LogHelper.LogEvent(new LogEventRequest(_logger)
                {
                    Exception = e,
                    LogLevel = LogLevel.Error,
                    Method = MethodBase.GetCurrentMethod(),
                    Values = new List<object>() { url, data, shopifySettings }
                });

                return string.Empty;
            }
        }

        /// <summary>
        /// Makes the POST request to shopify API with specified settings, data to post and URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="data">The data.</param>
        /// <param name="shopifySettings">The shopify settings.</param>
        /// <returns>Returns JSON response</returns>
        public static string MakePost(string url, object data, ShopifySettings shopifySettings)
        {
            try
            {
                WaitLimit();

                var client = GetClient(shopifySettings);

                var request = new RestRequest(url, Method.POST)
                {
                    RequestFormat = DataFormat.Json,
                    JsonSerializer = new RestSharpJsonNetSerializer()
                };

                request.AddParameter("application/json", data, ParameterType.RequestBody);

                var response = client.Execute(request);

                var res = CheckHeader(response);

                return res == RequestState.Repeat ? MakePost(url, data, shopifySettings) : response.Content;
            }
            catch (Exception e)
            {
                LogHelper.LogEvent(new LogEventRequest(_logger)
                {
                    Exception = e,
                    LogLevel = LogLevel.Error,
                    Method = MethodBase.GetCurrentMethod(),
                    Values = new List<object>() { url, data, shopifySettings }
                });

                return string.Empty;
            }
        }

        public static bool HasShopifyHeader(string url)
        {
            var client = new RestClient("https://" + url);

            var request = new RestRequest("", Method.POST)
            {
                RequestFormat = DataFormat.Json,
                JsonSerializer = new RestSharpJsonNetSerializer()
            };

            var response = client.Execute(request);

            return response.Headers.Any(h => h.Name == "X-ShopId");
        }

    }
}
