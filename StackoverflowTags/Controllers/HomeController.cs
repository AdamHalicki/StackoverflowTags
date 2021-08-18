using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StackoverflowTags.Models;
using StackoverflowTags.Models.Entities;
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
        private readonly ITagRepository _tagRepository;

        public HomeController( ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task<IActionResult> Index()
        {
            TagItem tagItem = new TagItem();

            tagItem = await _tagRepository.GetTagsAsync();

            decimal sum = tagItem.Items.Sum(i => i.Count);
            tagItem.Items.ForEach(ti => ti.Percentage = ti.Count / sum * 100);
            tagItem.PageId = 1;

            return View(tagItem);
        }

        [HttpPost]
        public async Task<IActionResult> Index(int pageId)
        {
            TagItem tagItem = new TagItem();

            tagItem = await _tagRepository.GetTagsAsync(pageId);

            decimal sum = tagItem.Items.Sum(i => i.Count);
            tagItem.Items.ForEach(ti => ti.Percentage = ti.Count / sum * 100);

            return View(tagItem);
        }
    }
}
