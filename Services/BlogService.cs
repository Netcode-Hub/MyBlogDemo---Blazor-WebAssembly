using MyBlogDemo.Shared;
using System.Net.Http.Json;
using System.Runtime.Serialization.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MyBlogDemo.Client.Services
{
    public class BlogService : IBlogService
    {
        private readonly HttpClient httpClient;
        public BlogService(HttpClient httpClient)
        { this.httpClient = httpClient; }

        public async Task<List<BlogPost>?> GetAllBlogPosts()
        {
           return await httpClient.GetFromJsonAsync<List<BlogPost>>("api/Blogs");
        }


        public async Task<BlogPost?> GetBlogPostUrl(string url)
        {
            var result = await httpClient.GetAsync($"api/Blogs/{url}");
            if (result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var message = await result.Content.ReadAsStringAsync();
                Console.WriteLine(message);
                return new BlogPost { Title = message };
            }
            else
            { return await result.Content.ReadFromJsonAsync<BlogPost>(); }
        }

        public async Task<List<BlogPost>> SearchBlogs(string searchText)
        {
            return await httpClient.GetFromJsonAsync<List<BlogPost>>($"api/Blogs/search/{searchText}");
        }

        public async Task<BlogPost?> CreateNewBlogPost(BlogPost request)
        {
            var result =  await httpClient.PostAsJsonAsync("api/Blogs", request);
            return await result.Content.ReadFromJsonAsync<BlogPost>();
        }
    }
}
