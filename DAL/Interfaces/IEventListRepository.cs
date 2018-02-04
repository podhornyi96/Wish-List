using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Objects.Common;
using BL.Objects.Lists.Event;

namespace DAL.Interfaces
{
    internal interface IEventListRepository
    {
        SearchResponse<EventList> Get(object obj);
        long Modify(EventList eventList);
        void Delete(object obj);
    }
}
