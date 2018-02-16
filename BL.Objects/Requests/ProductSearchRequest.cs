using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Objects.Requests
{
    public class ProductSearchRequest
    {
        public string Title { get; set; }
        public long StoreId { get; set; }
        public int Page { get; set; }
        public int Limit { get; set; }
    }
}
