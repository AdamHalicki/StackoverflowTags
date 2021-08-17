using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StackoverflowTags.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace StackoverflowTags.Controllers
{
    public class HomeController : Controller
    {

        public async Task<IActionResult> Index()
        {
            TagItem tagItem = new TagItem();
            HttpClientHandler handler = new HttpClientHandler();
            handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            using (var httpClient = new HttpClient(handler))
            {
                for(int i = 1; i < 11; i++)
                {
                    using (var response = await httpClient
                            .GetAsync("https://api.stackexchange.com/2.3/tags?order=desc&sort=popular&site=stackoverflow&pagesize=100&page=" + i))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        var tagObject = JsonConvert.DeserializeObject<TagItem>(apiResponse);
                        tagItem.Items.AddRange(tagObject.Items);
                    }
                }
            }

            decimal sum = tagItem.Items.Sum(i => i.Count);
            tagItem.Items.ForEach(ti => ti.Percentage = ti.Count / sum * 100);

            return View(tagItem);
        }
    }
}
