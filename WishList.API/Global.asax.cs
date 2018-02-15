using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace WishList.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

            if (Request.HttpMethod == "OPTIONS")
            {
                if (Response.Headers.AllKeys.Contains("Content-Type"))
                    Response.Headers.Remove("Content-Type");

                if (Response.Headers.AllKeys.Contains("Content-Length"))
                    Response.Headers.Remove("Content-Length");

                Response.StatusCode = 200;
                Response.End();
            }
        }

    }
}
