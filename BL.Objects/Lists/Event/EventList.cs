using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Objects.Common;
using BL.Objects.Lists.Product;

namespace BL.Objects.Lists.Event
{
    public class EventList : BaseEntity
    {
        public string OwnerId { get; set; }
        public long? StoreId { get; set; } // TODO: think if needed
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? Date { get; set; } //TODO: change to required
        public List<ProductList> ProductLists { get; set; } = new List<ProductList>();
    }
}
