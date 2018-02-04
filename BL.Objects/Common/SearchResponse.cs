using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Objects.Common
{
    public class SearchResponse<T>
    {
        public List<T> Data { get; set; }
        public int TotalRows { get; set; }
    }
}
