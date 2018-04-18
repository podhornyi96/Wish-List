using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BL.Objects.Requests;
using BL.Services.Implementations;
using BL.Services.Interfaces;

namespace WishList.API.Controllers
{
    [RoutePrefix("product")]
    public class ProductController : ApiController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [Route("")]
        [HttpGet]
        public IHttpActionResult Search([FromUri] ProductSearchRequest request)
        {
            return Ok(_productService.Search(request));
        }

    }
}
