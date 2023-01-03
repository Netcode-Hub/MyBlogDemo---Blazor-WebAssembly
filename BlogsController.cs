using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlogDemo.Server.Repositories;
using MyBlogDemo.Shared;

namespace MyBlogDemo.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IBlogRepository blogRepository;

        public BlogsController(IBlogRepository blogRepository)
        { this.blogRepository = blogRepository; }

        [HttpGet]
        public async Task<ActionResult<BlogPost>> GimmeAllPosts()
        { return Ok(await blogRepository.GetAllBlogPosts()); }


        [HttpGet("{url}")]
        public async Task<ActionResult<BlogPost>> GimmeSinglePost(string url)
        { return Ok(await blogRepository.GetBlogPostUrl(url)); }


        [HttpPost]
        public async Task<ActionResult<BlogPost>> CreateNewBlogPost(BlogPost request)
        { return Ok( await blogRepository.CreateNewBlogPost(request)); }

        [HttpGet("search/{searchText}")]
        public async Task<ActionResult<List<BlogPost>>> SearchBlogs(string searchText)
        { return Ok(await blogRepository.SearchBlogs(searchText)); }
    }
}
