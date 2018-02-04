using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BL.Objects.Lists.Event;
using BL.Services.Implementations;

namespace WishList.API.Controllers
{
    [RoutePrefix("lists/event")]
    public class EventListController : ApiController
    {
        private readonly EventListService _eventListService = new EventListService();

        [Route("")]
        [HttpGet]
        public IHttpActionResult Search() //TODO: request
        {
            return Unauthorized();
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult Create(EventList list)
        {
            return Ok(_eventListService.GetById(_eventListService.Modify(list)));
        }

        [Route("{id:int}")]
        [HttpPost]
        public IHttpActionResult Update(EventList list)
        {
            return Ok(_eventListService.GetById(_eventListService.Modify(list)));
        }

        [Route("{id:int}")]
        [HttpDelete]
        public IHttpActionResult Delete(long id)
        {
            try
            {
                _eventListService.Delete(id);
            }
            catch
            {
                //TODO: add logging
                return BadRequest();
            }

            return Ok();
        }

    }
}
