using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Objects.Common;
using Newtonsoft.Json;

namespace BL.Objects.Stores
{
    public class Store : BaseEntity
    {
        public string Host { get; set; }
        [JsonIgnore]
        public string Code { get; set; }
        [JsonIgnore]
        public string AccessToken { get; set; }
        [JsonIgnore]
        public string Nonce { get; set; }
        [JsonIgnore]
        public StoreOptions Options { get; set; }
    }

    [Flags]
    public enum StoreOptions
    {
        Disabled = 1
    }
}
