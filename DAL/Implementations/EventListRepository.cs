using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Objects.Common;
using BL.Objects.Lists.Event;
using BL.Objects.Lists.Extensions;
using BL.Objects.Lists.Product;
using Dapper;
using DAL.Interfaces;

namespace DAL.Implementations
{
    public class EventListRepository : IEventListRepository
    {
        public SearchResponse<EventList> Get(object obj)
        {
            using (var multi = Repository.GetConnection().QueryMultiple("dbo.EventListGet", obj, commandTimeout: int.MaxValue, commandType: System.Data.CommandType.StoredProcedure))
            {
                var eventLists = multi.Read<EventList>().ToDictionary(x => x.Id, x => x); ;

                multi.Read<long, ProductList, int>((eventListId, productItem) =>
                {
                    if (!eventLists.ContainsKey(eventListId))
                        return 0;

                    eventLists[eventListId].ProductLists.Add(productItem);

                    return 0;
                }, splitOn: "EventId,Id");

                var totalRows = multi.Read<int>().FirstOrDefault();

                return new SearchResponse<EventList>
                {
                    Data = eventLists.Values.ToList(),
                    TotalRows = totalRows
                };
            }
        }

        public long Modify(EventList eventList)
        {
            return Repository.GetConnection().Query<long>("dbo.EventListModify", new
            {
                Id = eventList.Id,
                Title = eventList.Title,
                Description = eventList.Description,
                Date = eventList.Date,
                OwnerId = eventList.OwnerId,
                StoreId = eventList.StoreId,
                ProuctLists = eventList.ProductLists.ToTvp().AsTableValuedParameter()
            }, commandType: CommandType.StoredProcedure, commandTimeout: int.MaxValue).First();
        }

        public void Delete(object obj)
        {
            Repository.GetConnection()
                .Query<bool>("dbo.EventListDelete", obj, commandType: CommandType.StoredProcedure, commandTimeout: int.MaxValue);
        }
    }
}
