using Microsoft.EntityFrameworkCore;
using MyBlogDemo.Server.Data;
using MyBlogDemo.Shared;

namespace MyBlogDemo.Server.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly AppDbContext appDbContext;
        public BlogRepository(AppDbContext appDbContext)
        { this.appDbContext = appDbContext;  }


        public async Task<List<BlogPost>?> GetAllBlogPosts()
        { return await appDbContext.BlogPosts.OrderByDescending(post => post.DateCreated).ToListAsync(); }


        public async Task<BlogPost?> GetBlogPostUrl(string url)
        { return await appDbContext.BlogPosts.FirstOrDefaultAsync(p => p.Url.ToLower().Equals(url.ToLower())); }


        public async Task<BlogPost?> CreateNewBlogPost(BlogPost request)
        {
            appDbContext.BlogPosts.Add(request);
            await appDbContext.SaveChangesAsync();
            return request;
        }

        public async Task<List<BlogPost>> SearchBlogs(string searchText)
        { return await appDbContext.BlogPosts.Where(p => p.Title.ToLower().Contains(searchText.ToLower())).ToListAsync(); }
    }
}
