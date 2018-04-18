using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Objects.Stores;

namespace DAL.Interfaces
{
    public interface IStoreRepository
    {
        List<Store> Get(object obj);
        long Update(Store store);
        void Delete(object obj);
    }
}
