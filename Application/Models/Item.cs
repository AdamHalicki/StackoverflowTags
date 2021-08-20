using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class Item
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("count")]
        public int Count { get; set; }
        public decimal Percentage { get; set; }
    }
}
