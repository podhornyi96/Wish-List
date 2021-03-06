﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BL.Objects.Lists.Event;
using BL.Objects.Requests;
using BL.Services.Implementations;
using BL.Services.Interfaces;

namespace WishList.API.Controllers
{
    [RoutePrefix("lists/event")]
    public class EventListController : ApiController
    {
        private readonly IEventListService _eventListService;

        public EventListController(IEventListService eventListService)
        {
            _eventListService = eventListService;
        }

        [Route("")]
        [HttpGet]
        public IHttpActionResult Search([FromUri] EventListSearchRequest request)
        {
            return Ok(_eventListService.Search(request));
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

        [Route("{id:long}")]
        [HttpDelete]
        public IHttpActionResult Delete(long id)
        {
            try
            {
                _eventListService.Delete(id);
            }
            catch (Exception e)
            {
                return BadRequest();
            }

            return Ok();
        }

    }
}
