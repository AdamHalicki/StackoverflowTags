using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface ITagService
    {
        public Task<TagItem> GetTagsAsync();
        public Task<TagItem> GetTagsAsync(int pageId);
        public Task<TagItem> GetAllTagsAsync();
    }
}
