using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Objects.Stores;
using Dapper;
using DAL.Interfaces;

namespace DAL.Implementations
{
    public class StoreRepository : IStoreRepository
    {
        public List<Store> Get(object obj)
        {
            using (var multi = Repository.GetConnection().QueryMultiple("dbo.StoreGet", obj, commandTimeout: int.MaxValue, commandType: CommandType.StoredProcedure))
            {
                return multi.Read<Store>().ToList();
            }
        }

        public long Update(Store store)
        {
            return Repository.GetConnection().Query<long>("dbo.StoreModify", new
            {
                Id = store.Id,
                Nonce = store.Nonce,
                Host = store.Host,
                Code = store.Code,
                AccessToken = store.AccessToken,
                Options = store.Options
            }, commandType: CommandType.StoredProcedure, commandTimeout: int.MaxValue).First();
        }

        public void Delete(object obj)
        {
            Repository.GetConnection()
                .Query<bool>("dbo.StoreDelete", obj, commandType: CommandType.StoredProcedure, commandTimeout: int.MaxValue);
        }

    }
}
