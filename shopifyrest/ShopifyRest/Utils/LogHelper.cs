using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using NLog;

namespace ShopifyRest.Utils
{
    /// <summary>
    /// 
    /// </summary>
    public class LogEventRequest
    {
        /// <summary>
        /// 
        /// </summary>
        public Exception Exception { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<Tuple<string, object>> ExtraData { get; set; } = new List<Tuple<string, object>>();

        /// <summary>
        /// 
        /// </summary>
        public List<object> Values { get; set; } = new List<object>();

        /// <summary>
        /// 
        /// </summary>
        public MethodBase Method { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Logger Logger { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public LogLevel LogLevel { get; set; } = LogLevel.Error;

        /// <summary>
        /// 
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ResponseCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        public LogEventRequest(Logger log)
        {
            Logger = log;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public static class LogHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        public static void LogEvent(LogEventRequest request)
        {
            if (string.IsNullOrEmpty(request.Message) && request.Exception != null)
                request.Message = request.Exception.Message;

            var theEvent = new LogEventInfo(request.LogLevel ?? LogLevel.Info, request.Logger.Name, request.Message)
            {
                Exception = request.Exception
            };

            if (request.Method == null)
            {
                var stackTrace = new StackTrace();
                request.Method = stackTrace.GetFrame(1).GetMethod();
            }

            theEvent.Properties["MethodName"] = request.Method.Name;

            var httpContext = HttpContext.Current;

            if (request.ResponseCode != default(int))
                theEvent.Properties["HttpResponseCode"] = request.ResponseCode;

            if (httpContext?.Response != null && request.ResponseCode == default(int))
                theEvent.Properties["HttpResponseCode"] = httpContext.Response.StatusCode;

            if (httpContext?.Request != null)
            {
                theEvent.Properties["UserAgent"] = httpContext.Request.UserAgent;
                theEvent.Properties["UrlReferrer"] = httpContext.Request.UrlReferrer;
            }

            if (request.Method != null && request.Values != null && request.Values.Any())
            {
                var dic = new Dictionary<string, object>();

                var parms = request.Method.GetParameters();

                for (var i = 0; i < parms.Length; i++)
                {
                    dic.Add(parms[i].Name, i >= request.Values.Count ? null : request.Values[i]);
                }

                theEvent.Properties["MethodParameters"] = dic;
            }

            if (request.ExtraData != null && request.ExtraData.Any())
            {
                foreach (var data in request.ExtraData)
                {
                    theEvent.Properties[data.Item1] = data.Item2;
                }
            }

            theEvent.Properties["AllProperties"] = JsonConvert.SerializeObject(theEvent.Properties);

            request.Logger.Log(theEvent);
        }
    }
}
