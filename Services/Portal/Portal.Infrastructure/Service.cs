using Portal.Infrastructure.Services.Posts;

namespace Portal.Infrastructure
{
    public interface IService
    {
        public IPostService PostService { get; }
    }

    public class Service : IService
    {
        public IPostService PostService { get; }

        public Service(
            IPostService postService)
        {
            PostService = postService;
        }
    }
}