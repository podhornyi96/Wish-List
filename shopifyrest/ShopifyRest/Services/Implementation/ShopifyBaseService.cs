using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NLog;
using ShopifyRest.Objects;
using ShopifyRest.Objects.Attributes;
using ShopifyRest.Objects.Common;
using ShopifyRest.Objects.Exceptions;
using ShopifyRest.Objects.Extensions;
using ShopifyRest.Utils;

namespace ShopifyRest.Services.Implementation
{
    /*TODO make a realization of methods, set url in constructor */
    public abstract class ShopifyBaseService
    {
        protected ShopifyBaseService(ShopifySettings settings, string url)
        {
            Url = url;
            Settings = settings;
        }

        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        internal string Url { get; set; }

        /// <summary>
        /// Gets or sets the settings.
        /// </summary>
        /// <value>
        /// The settings.
        /// </value>
        protected ShopifySettings Settings { get; set; }

        internal virtual List<T> GetAll<T>(long id, string url = null) where T : IShopifyBaseObject
        {
            var result = new List<T>();
            List<T> response;

            do
            {
                var logRequest = new LogEventRequest(_logger)
                {
                    LogLevel = LogLevel.Info,
                    Method = MethodBase.GetCurrentMethod(),
                    Message = "Get all",
                    ExtraData = new List<Tuple<string, object>>()
                    {
                        new Tuple<string, object>("Url", url ?? $"{Url}?limit=250&since_id={id}"),
                        new Tuple<string, object>("Settings", Settings),
                        new Tuple<string, object>("ID", id),
                    }
                };

                LogHelper.LogEvent(logRequest);

                var jsonResp = Net.MakeGet(url ?? $"{Url}?limit=250&since_id={id}", Settings);

                ContainsError(jsonResp, "id:" + id.ToString(), url ?? Url);

                response = ParseResponse<List<T>>(jsonResp);

                logRequest.LogLevel = LogLevel.Trace;
                logRequest.ExtraData.Add(new Tuple<string, object>("Response", response));

                LogHelper.LogEvent(logRequest);

                if (response == null) break;

                result.AddRange(response);

                if (response.Count == 250)
                {
                    id = (long)response.Last().Id;
                }

            } while (response.Count == 250);

            return result;
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="url"></param>
        /// <returns></returns>
        public virtual T GetByID<T>(long id, string url = null)
        {
            var logRequest = new LogEventRequest(_logger)
            {
                LogLevel = LogLevel.Info,
                Method = MethodBase.GetCurrentMethod(),
                Message = "Get by ID",
                ExtraData = new List<Tuple<string, object>>()
                {
                    new Tuple<string, object>("Url", url ?? $"{Url.Split('.')[0]}/{id}.json"),
                    new Tuple<string, object>("Settings", Settings),
                    new Tuple<string, object>("ID", id),
                }
            };

            LogHelper.LogEvent(logRequest);

            var resp = Net.MakeGet(url ?? $"{Url.Split('.')[0]}/{id}.json", Settings);

            logRequest.LogLevel = LogLevel.Trace;
            logRequest.ExtraData.Add(new Tuple<string, object>("Response", resp));

            LogHelper.LogEvent(logRequest);

            ContainsError(resp, "id:" + id.ToString(), url ?? Url);

            return ParseResponse<T>(resp);
        }

        /// <summary>
        /// Gets the by ids.
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <param name="url"></param>
        /// <returns></returns>
        public virtual List<T> GetByIDs<T>(List<long> ids, string url = null)
        {
            var idsToGet = ids.ChunkBy(250);

            var result = new List<T>();

            foreach (var idToget in idsToGet)
            {
                var logRequest = new LogEventRequest(_logger)
                {
                    LogLevel = LogLevel.Info,
                    Method = MethodBase.GetCurrentMethod(),
                    Message = "Get by Ids",
                    ExtraData = new List<Tuple<string, object>>()
                    {
                        new Tuple<string, object>("Url", url ?? $"{Url}?ids={string.Join(",", ids)}"),
                        new Tuple<string, object>("Settings", Settings),
                        new Tuple<string, object>("IDs", ids)
                    }
                };

                LogHelper.LogEvent(logRequest);

                var resp = Net.MakeGet(url ?? $"{Url}?limit=250&ids={string.Join(",", idToget)}", Settings);

                ContainsError(resp, "ids: " + string.Join(",", idToget), url ?? Url);

                var response = ParseResponse<List<T>>(resp);

                logRequest.LogLevel = LogLevel.Trace;
                logRequest.ExtraData.Add(new Tuple<string, object>("Response", resp));

                LogHelper.LogEvent(logRequest);

                if (response != null)
                    result.AddRange(response);
            }

            return result;
        }

        /// <summary>
        /// Deletes by the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="url"></param>
        public virtual void Delete(long id, string url = null)
        {
            var logRequest = new LogEventRequest(_logger)
            {
                LogLevel = LogLevel.Info,
                Method = MethodBase.GetCurrentMethod(),
                Message = "Delete",
                ExtraData = new List<Tuple<string, object>>()
                {
                    new Tuple<string, object>("Url", url ?? $"{Url.Split('.')[0]}/{id}.json"),
                    new Tuple<string, object>("Settings", Settings),
                    new Tuple<string, object>("ID", id),
                }
            };

            LogHelper.LogEvent(logRequest);

            var resp = Net.MakeDelete(url ?? $"{Url.Split('.')[0]}/{id}.json", Settings);

            logRequest.LogLevel = LogLevel.Trace;
            logRequest.ExtraData.Add(new Tuple<string, object>("Response", resp));

            LogHelper.LogEvent(logRequest);

            ContainsError(resp, "id: " + id.ToString(), url ?? Url);
        }

        /// <summary>
        /// Creates the specified t.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t">The t.</param>
        /// <returns></returns>
        public virtual T Create<T>(T t, string url = null)
        {
            var request = JsonConvert.SerializeObject(AppendRootLevel(t));

            var logRequest = new LogEventRequest(_logger)
            {
                LogLevel = LogLevel.Info,
                Method = MethodBase.GetCurrentMethod(),
                Message = "Create",
                ExtraData = new List<Tuple<string, object>>()
                {
                    new Tuple<string, object>("Url", url ?? Url),
                    new Tuple<string, object>("Settings", Settings),
                    new Tuple<string, object>("Request", request)
                }
            };

            LogHelper.LogEvent(logRequest);


            var resp = Net.MakePost(url ?? Url, request, Settings);

            logRequest.LogLevel = LogLevel.Trace;
            logRequest.ExtraData.Add(new Tuple<string, object>("Response", resp));

            LogHelper.LogEvent(logRequest);

            ContainsError(resp, request, url ?? Url);

            return ParseResponse<T>(resp);
        }

        /// <summary>
        /// Updates the specified t.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t">The t.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public virtual T Update<T>(T t, long id, string url = null)
        {
            var resultUrl = url ?? $"{Url.Split('.')[0]}/{id}.json";

            var request = AppendRootLevel(t);

            var logRequest = new LogEventRequest(_logger)
            {
                LogLevel = LogLevel.Info,
                Method = MethodBase.GetCurrentMethod(),
                Message = "Update",
                ExtraData = new List<Tuple<string, object>>()
                {
                    new Tuple<string, object>("Url", url ?? $"{Url.Split('.')[0]}/{id}.json"),
                    new Tuple<string, object>("Settings", Settings),
                    new Tuple<string, object>("ID", id),
                    new Tuple<string, object>("Request", request),
                }
            };

            LogHelper.LogEvent(logRequest);

            var resp = Net.MakePut(resultUrl, request,
                             Settings);

            logRequest.LogLevel = LogLevel.Trace;
            logRequest.ExtraData.Add(new Tuple<string, object>("Request", request));

            LogHelper.LogEvent(logRequest);

            ContainsError(resp, JsonConvert.SerializeObject(request), url);

            return ParseResponse<T>(resp);
        }

        public virtual T Post<T, T2>(string url, T2 t = default(T2))
        {
            var request = Equals(t, default(T2)) ? (object)new { } : JsonConvert.SerializeObject(AppendRootLevel(t));

            var logRequest = new LogEventRequest(_logger)
            {
                LogLevel = LogLevel.Info,
                Method = MethodBase.GetCurrentMethod(),
                Message = "Post",
                ExtraData = new List<Tuple<string, object>>()
                {
                    new Tuple<string, object>("Url", url),
                    new Tuple<string, object>("Settings", Settings),
                    new Tuple<string, object>("Request", request),
                }
            };

            LogHelper.LogEvent(logRequest);

            var resp = Net.MakePost(url, request, Settings);

            logRequest.LogLevel = LogLevel.Trace;
            logRequest.ExtraData.Add(new Tuple<string, object>("Response", resp));

            LogHelper.LogEvent(logRequest);

            if (!string.IsNullOrEmpty(resp))
                ContainsError(resp, JsonConvert.SerializeObject(request), url);

            return ParseResponse<T>(resp);
        }

        public virtual List<T> Get<T>(string url)
        {
            var logRequest = new LogEventRequest(_logger)
            {
                LogLevel = LogLevel.Info,
                Method = MethodBase.GetCurrentMethod(),
                Message = "Get from",
                ExtraData = new List<Tuple<string, object>>()
                {
                    new Tuple<string, object>("Url", url),
                    new Tuple<string, object>("Settings", Settings)
                }
            };

            LogHelper.LogEvent(logRequest);

            var resp = Net.MakeGet(url, Settings);

            logRequest.LogLevel = LogLevel.Trace;
            logRequest.ExtraData.Add(new Tuple<string, object>("Response", resp));

            LogHelper.LogEvent(logRequest);

            if (!string.IsNullOrEmpty(resp))
                ContainsError(resp, "", url);


            return ParseResponse<List<T>>(resp);
        }

        public virtual string Delete(string url)
        {
            var logRequest = new LogEventRequest(_logger)
            {
                LogLevel = LogLevel.Info,
                Method = MethodBase.GetCurrentMethod(),
                Message = "Delete",
                ExtraData = new List<Tuple<string, object>>()
                {
                    new Tuple<string, object>("Url", url),
                    new Tuple<string, object>("Settings", Settings)
                }
            };

            LogHelper.LogEvent(logRequest);

            var resp = Net.MakeDelete(url, Settings);

            logRequest.LogLevel = LogLevel.Trace;
            logRequest.ExtraData.Add(new Tuple<string, object>("Response", resp));

            LogHelper.LogEvent(logRequest);

            ContainsError(resp, "", url);

            return ParseResponse<string>(resp);
        }

        /// <summary>
        /// Filters this instance.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public virtual T Filter<T, TReturn>(TReturn filter, string url = null)
        {
            var logRequest = new LogEventRequest(_logger)
            {
                LogLevel = LogLevel.Info,
                Method = MethodBase.GetCurrentMethod(),
                Message = "Filter",
                ExtraData = new List<Tuple<string, object>>()
                {
                    new Tuple<string, object>("Url", url ?? Url),
                    new Tuple<string, object>("Settings", Settings),
                    new Tuple<string, object>("Filter", filter)
                }
            };

            LogHelper.LogEvent(logRequest);

            var dict = ExtractParams(filter);
            var filterUrl = "?";

            foreach (var x in dict.Select((entry, i) => new { entry, i }))
            {
                if (x.entry.Value.Any())
                {
                    if (x.i != 0)
                        filterUrl += "&";

                    filterUrl += x.entry.Key + "=" + x.entry.Value[0];
                    for (var i = 1; i < x.entry.Value.Count; i++)
                    {
                        filterUrl += "," + x.entry.Value[i];
                    }
                }

            }

            var resp = Net.MakeGet((url ?? Url) + filterUrl, Settings);

            logRequest.LogLevel = LogLevel.Trace;
            logRequest.ExtraData.Add(new Tuple<string, object>("Response", resp));

            LogHelper.LogEvent(logRequest);

            ContainsError(resp, url + filterUrl, url);

            return ParseResponse<T>(resp);
        }

        private Dictionary<string, List<string>> ExtractParams<T>(T t)
        {
            var dict = new Dictionary<string, List<string>>();

            var fields = t.GetType().GetProperties();

            foreach (var propertyInfo in fields)
            {
                var val = propertyInfo.GetValue(t, null);

                if (val == null)
                    continue;

                var res = (ShopifyFilterObject)propertyInfo.GetCustomAttribute(typeof(ShopifyFilterObject));

                if (IsList(val) && ((IList)val).Count > 0)
                {
                    dict[res.Name] = ToListString((IList)val);
                }
                else if (!IsList(val) && !string.IsNullOrEmpty(val.ToString()))
                {
                    dict[res.Name] = new List<string>() { val.ToString() };
                }
            }

            return dict;
        }

        public string GetEnumValue(object value)
        {
            var enumType = value.GetType();

            var name = Enum.GetName(enumType, value);
            var enumMemberAttribute = ((EnumMemberAttribute[])enumType.GetField(name).GetCustomAttributes(typeof(EnumMemberAttribute), true)).Single();

            return enumMemberAttribute.Value;
        }

        public bool IsList(object o)
        {
            if (o == null) return false;
            return o is IList &&
                   o.GetType().IsGenericType &&
                   o.GetType().GetGenericTypeDefinition().IsAssignableFrom(typeof(List<>));
        }

        private List<string> ToListString(IList list)
        {
            var res = new List<string>();
            foreach (var value in list)
            {
                if (value is Enum)
                {
                    var a = GetEnumValue(value);
                }
                else
                {
                    res.Add(value.ToString());
                }
            }

            return res;
        }

        /// <summary>
        /// Parses the response.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reponse">The reponse.</param>
        /// <returns></returns>
        private T ParseResponse<T>(string reponse)
        {
            if (string.IsNullOrEmpty(reponse))
                return default(T);

            var args = typeof(T).GetGenericArguments();

            ShopifyRootObject shopifyRootObject;

            if (args.Length == 0)
            {
                shopifyRootObject = (ShopifyRootObject)Attribute.GetCustomAttribute(typeof(T), typeof(ShopifyRootObject));
            }
            else
            {
                shopifyRootObject = (ShopifyRootObject)Attribute.GetCustomAttribute(typeof(T).GetGenericArguments()[0], typeof(ShopifyRootObject));
            }

            if (shopifyRootObject == null)
                return JsonConvert.DeserializeObject<T>(reponse);

            if (!reponse.Contains(shopifyRootObject.Name))
                return default(T);

            var type = typeof(T);
            var inputType = typeof(T);

            var jObject = JObject.Parse(reponse);

            var first = jObject.First;

            var isSingle = false;

            if (!first.Path.EndsWith("s") && type.IsGenericType)
            {
                type = type.GetGenericArguments()[0];

                isSingle = true;
            }

            var result = first.Value<JProperty>().Value.ToObject(type);

            if (isSingle && (inputType.GetGenericTypeDefinition() == typeof(List<>)))
            {
                var x = (T)Activator.CreateInstance(typeof(T));

                x.GetType().GetMethod("Add").Invoke(x, new[] { result });

                return x;
            }

            return (T)result;
        }

        private object AppendRootLevel<T>(T t)
        {
            ShopifyRootObject shopifyRootObject = (ShopifyRootObject)Attribute.GetCustomAttribute(typeof(T), typeof(ShopifyRootObject));

            if (shopifyRootObject == null)
                return t;

            var rootObject = new ExpandoObject() as IDictionary<string, Object>;

            rootObject.Add(shopifyRootObject.Name, t);

            return rootObject;
        }

        private List<string> ParseError(string resp)
        {
            var result = new List<string>();

            dynamic parsedResponce = JsonConvert.DeserializeObject(resp);

            if (!IsList(parsedResponce.errors))
            {
                if (parsedResponce.errors.Value == null)
                {
                    result.Add(JObject.Parse(resp).First.First.First.Value<JProperty>().Name + ": " + JObject.Parse(resp).First.First.First.Value<JProperty>().Value.ToString());
                }
                else
                {
                    result.Add(parsedResponce.errors.Value.ToString());
                }
                return result;
            }

            foreach (dynamic entry in parsedResponce.errors)
            {
                foreach (var err in entry.Value)
                {
                    result.Add(entry.Name.ToString() + ": " + err.ToString());
                }
            }

            return result;
        }


        private void ContainsError(string response, string request, string url)
        {
            if (string.IsNullOrEmpty(response))
                return;

            var errors = JObject.Parse(response);

            if (errors["errors"] != null)
            {
                var errorsList = new List<string>();

                var t = errors["errors"];

                if (!t.Values().GetType().IsArray)
                {
                    errorsList.Add(t.ToString());
                }
                else if (t.Values().GetType().IsArray)
                {
                    errorsList.AddRange((from e in errors["errors"] let dynamic = e select ((dynamic)dynamic).Name + " :  " + string.Join(", ", e.Values())).Cast<string>());
                }

                var errorMessage = errors.Count > 1 ? "One or more errors occured" : errorsList.Count != 0 ? errorsList[0] : "error occured";

                var ex = new ShopifyException(errorMessage, errorsList, response, request, url);

                LogHelper.LogEvent(new LogEventRequest(_logger)
                {
                    Exception = ex,
                    LogLevel = LogLevel.Error,
                    Method = MethodBase.GetCurrentMethod(),
                    Values = new List<object>() { url, Settings, request, response }
                });

                throw ex;

            }

        }

    }
}