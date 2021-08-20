using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
        private readonly ITagService _tagService;

        public HomeController(ITagService tagService)
        {
            _tagService = tagService;
        }

        public async Task<IActionResult> Index()
        {
            var tagItem = await _tagService.GetTagsAsync();

            return View(tagItem);
        }

        [HttpPost]
        public async Task<IActionResult> Index(int pageId)
        {
            if(pageId != -1)
            {
                var tagItem = await _tagService.GetTagsAsync(pageId);
                return View(tagItem);
            }
            else
            {
                var tagItem = await _tagService.GetAllTagsAsync();
                return View(tagItem);
            }
        }
    }
}
