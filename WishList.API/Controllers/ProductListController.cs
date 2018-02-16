using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BL.Objects.Lists.Product;
using BL.Objects.Requests;
using BL.Services.Implementations;

namespace WishList.API.Controllers
{
    [RoutePrefix("lists/product")]
    public class ProductListController : ApiController
    {
        private readonly ProductListService _productListService = new ProductListService();

        [Route("")]
        [HttpGet]
        public IHttpActionResult Search([FromUri] ProductListSearchRequest request)
        {
            return Ok(_productListService.Search(request));
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult Create(ProductList list)
        {
            return Ok(_productListService.GetById(_productListService.Modify(list)));
        }

        [Route("{id:long}")]
        [HttpPost]
        public IHttpActionResult Update(ProductList list)
        {
            return Ok(_productListService.GetById(_productListService.Modify(list)));
        }

        [Route("{id:long}")]
        [HttpDelete]
        public IHttpActionResult Delete(long id)
        {
            try
            {
                _productListService.Delete(id);
            }
            catch (Exception e)
            {
                return BadRequest();
            }

            return Ok();
        }

    }
}
