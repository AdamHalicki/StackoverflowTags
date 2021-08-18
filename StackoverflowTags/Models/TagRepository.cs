using Newtonsoft.Json;
using StackoverflowTags.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace StackoverflowTags.Models
{
    public class TagRepository : ITagRepository
    {
        public async Task<TagItem> GetTagsAsync()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (var httpClient = new HttpClient(handler))
            {
                using (var response = await httpClient
                        .GetAsync($"https://api.stackexchange.com/2.3/tags?order=desc&sort=popular&site=stackoverflow&pagesize=100&page=1"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var tagItem = JsonConvert.DeserializeObject<TagItem>(apiResponse);

                    return tagItem;
                }
            }
        }

        public async Task<TagItem> GetTagsAsync(int pageId)
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (var httpClient = new HttpClient(handler))
            {
                using (var response = await httpClient
                        .GetAsync($"https://api.stackexchange.com/2.3/tags?order=desc&sort=popular&site=stackoverflow&pagesize=100&page={pageId}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var tagItem = JsonConvert.DeserializeObject<TagItem>(apiResponse);

                    return tagItem;
                }
            }
        }
    }
}
