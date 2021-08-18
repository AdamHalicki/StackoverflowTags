using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StackoverflowTags.Models.Entities
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class Item
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("count")]
        public int Count { get; set; }
        public decimal Percentage { get; set; }
    }
}
