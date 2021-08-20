using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
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
