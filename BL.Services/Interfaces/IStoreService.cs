using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Objects.Stores;

namespace BL.Services.Interfaces
{
    interface IStoreService
    {
        long Update(Store store);
        List<Store> GetByIds(List<long> ids);
        Store GetById(long id);
        Store GetByHost(string host);
        void Delete(long id);
    }
}
