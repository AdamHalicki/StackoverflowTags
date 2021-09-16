using Application.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace StackOverflowTags.Tests.ServicesUnitTests
{
    public class TagServiceTest
    {
        [Fact]
        public async Task GetAllTagsAsync_Is1000Records()
        {
            TagService tagService = new TagService();
            var response = await tagService.GetAllTagsAsync();
            Assert.Equal(1000, response.Items.Count());
        }
    }
}
