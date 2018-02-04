using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Objects.Common;

namespace BL.Objects.Stores
{
    public class Store : BaseEntity
    {
        public string Host { get; set; }
        public string Code { get; set; }
        public string AccessToken { get; set; }
        public string Nonce { get; set; }
        public StoreOptions Options { get; set; }
    }

    [Flags]
    public enum StoreOptions
    {
        Disabled = 1
    }
}
