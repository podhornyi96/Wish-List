using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Objects.Lists.Extensions;
using BL.Objects.Stores;
using BL.Services.Interfaces;
using Dapper;
using DAL.Implementations;
using DAL.Interfaces;

namespace BL.Services.Implementations
{
    public enum StoreSearchType
    {
        ById = 1,
        ByHost = 2
    }

    public class StoreService : IStoreService
    {
        private readonly IStoreRepository _storeRepository;

        public StoreService(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public long Update(Store store)
        {
            return _storeRepository.Update(store);
        }

        public void Delete(long id)
        {
            _storeRepository.Delete(id);
        }

        public Store GetById(long id)
        {
            return GetByIds(new List<long>() {id}).FirstOrDefault();
        }

        public List<Store> GetByIds(List<long> ids)
        {
            return _storeRepository.Get(new { SearchType = StoreSearchType.ById, IDs = ids.ToTvpLongList().AsTableValuedParameter() });
        }

        public Store GetByHost(string host)
        {
            return _storeRepository.Get(new {Host = host, SearchType = StoreSearchType.ByHost}).FirstOrDefault();
        }
    }
}
