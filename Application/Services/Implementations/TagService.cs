using Application.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implementations
{
    public class TagService: ITagService
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

                    decimal sum = tagItem.Items.Sum(i => i.Count);
                    tagItem.Items.ForEach(ti => ti.Percentage = ti.Count / sum * 100);

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

                    decimal sum = tagItem.Items.Sum(i => i.Count);
                    tagItem.Items.ForEach(ti => ti.Percentage = ti.Count / sum * 100);

                    return tagItem;
                }
            }
        }

        public async Task<TagItem> GetAllTagsAsync()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            TagItem tagItem = new TagItem();

            using (var httpClient = new HttpClient(handler))
            {
                for (int i = 1; i < 11; i++)
                {
                    using (var response = await httpClient
                            .GetAsync($"https://api.stackexchange.com/2.3/tags?order=desc&sort=popular&site=stackoverflow&pagesize=100&page={i}"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        var tagObject = JsonConvert.DeserializeObject<TagItem>(apiResponse);
                        tagItem.Items.AddRange(tagObject.Items);
                    }
                }

                decimal sum = tagItem.Items.Sum(i => i.Count);
                tagItem.Items.ForEach(ti => ti.Percentage = ti.Count / sum * 100);
            }

            return tagItem;
        }
    }
}
