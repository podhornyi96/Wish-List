using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Objects.Requests
{
    public class ProductListSearchRequest : BaseSearchRequest
    {
        public string Title { get; set; }
        public override object ToDbRequest(int? searchType = null)
        {
            return new
            {
                Title = Title,
                Skip = Skip,
                Top = Top,
                SearchType = searchType ?? SearchType
            };
        }
    }
}
