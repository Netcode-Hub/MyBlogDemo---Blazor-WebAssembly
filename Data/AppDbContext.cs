using Microsoft.EntityFrameworkCore;
using MyBlogDemo.Shared;

namespace MyBlogDemo.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
        public DbSet<BlogPost> BlogPosts { get; set; }
    }
}
