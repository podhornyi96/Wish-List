using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BL.Objects.Requests;
using BL.Services.Implementations;

namespace WishList.API.Controllers
{
    [RoutePrefix("product")]
    public class ProductController : ApiController
    {

        [Route("")]
        [HttpGet]
        public IHttpActionResult Search([FromUri] ProductSearchRequest request)
        {
            return Ok(new ProductService().Search(request));
        }

    }
}
