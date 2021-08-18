using Microsoft.AspNetCore.Mvc;
using StackoverflowTags.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StackoverflowTags.Models
{
    public interface ITagRepository
    {
        public Task<TagItem> GetTagsAsync();
        public Task<TagItem> GetTagsAsync(int pageId);
        public Task GetAllTagsAsync(TagItem tagItem);
    }
}
