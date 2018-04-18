using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Objects.Common;
using BL.Objects.Lists.Event;
using BL.Objects.Requests;

namespace BL.Services.Interfaces
{
    public interface IEventListService
    {
        EventList GetById(long id);
        List<EventList> GetByIds(List<long> ids);
        SearchResponse<EventList> Search(EventListSearchRequest request);
        long Modify(EventList eventList);
        void Delete(long id);
        void Delete(List<long> ids);
    }
}
