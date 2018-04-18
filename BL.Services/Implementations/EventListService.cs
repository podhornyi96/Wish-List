using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Objects.Common;
using BL.Objects.Lists.Event;
using BL.Objects.Lists.Extensions;
using BL.Objects.Requests;
using BL.Services.Interfaces;
using Dapper;
using DAL.Implementations;
using DAL.Interfaces;

namespace BL.Services.Implementations
{
    public enum EventListSearchType
    {
        ByIds = 1,
        Params = 2
    }

    public class EventListService : IEventListService
    {
        private readonly IEventListRepository _eventListRepository;

        public EventListService(IEventListRepository eventListRepository)
        {
            _eventListRepository = eventListRepository;
        }

        public EventList GetById(long id)
        {
            return GetByIds(new List<long>() { id }).FirstOrDefault();
        }

        public List<EventList> GetByIds(List<long> ids)
        {
            return
                _eventListRepository.Get(
                    new { SearchType = EventListSearchType.ByIds, IDs = ids.ToTvpLongList().AsTableValuedParameter() }).Data;
        }

        public long Modify(EventList eventList)
        {
            return _eventListRepository.Modify(eventList);
        }

        public void Delete(long id)
        {
            Delete(new List<long>() { id });
        }

        public void Delete(List<long> ids)
        {
            _eventListRepository.Delete(new { IDs = ids.ToTvpLongList().AsTableValuedParameter() });
        }

        public SearchResponse<EventList> Search(EventListSearchRequest request)
        {
            return _eventListRepository.Get(request.ToDbRequest((int) EventListSearchType.Params));
        }
    }
}
