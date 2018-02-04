using System;
using System.Collections.Generic;

namespace ShopifyRest.Objects.Exceptions
{
    /// <summary>
    /// Custom exception that stores JSON request, response, 
    /// Url to which request has been done and errors if request failed.
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class ShopifyException : Exception
    {

        public string Url { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
        public string Response { get; set; }
        public string Request { get; set; }
        

        public ShopifyException(string message): base(message)
        {
            
        }

        public ShopifyException(string message, List<string> errors, string response, string request, string url) : base(message)
        {
            Errors = errors;
            Response = response;
            Request = request;
            Url = url;
        }

    }
}