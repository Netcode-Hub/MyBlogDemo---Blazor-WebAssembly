using MyBlogDemo.Shared;

namespace MyBlogDemo.Server.Repositories
{
    public interface IBlogRepository
    {
        Task<List<BlogPost>?> GetAllBlogPosts();
        Task<BlogPost?> GetBlogPostUrl(string url);
        Task<BlogPost?> CreateNewBlogPost(BlogPost request);
        Task<List<BlogPost>> SearchBlogs(string searchText);
    }
}
