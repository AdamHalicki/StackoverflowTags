using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StackoverflowTags.Models.Entities
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class TagItem
    {
        public TagItem()
        {
             Items = new List<Item>();
        }

        [JsonProperty("items")]
        public List<Item> Items { get; set; }

    }
}
