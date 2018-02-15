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
    [RoutePrefix("lists/product")]
    public class ProductListController : ApiController
    {
        private readonly ProductListService _eventListService = new ProductListService();

        [Route("")]
        [HttpGet]
        public IHttpActionResult Search([FromUri] ProductListSearchRequest request)
        {
            return Ok(_eventListService.Search(request));
        }

    }
}
