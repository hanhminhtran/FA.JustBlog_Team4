namespace FA.JustBlog.Core
{
    public interface IPostService
    {
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetPublishedPosts();
        IEnumerable<Post> GetUnpublishedPosts();
        IEnumerable<Post> GetLatestPost(int size);
        IEnumerable<Post> GetPostsByMonth(DateTime monthYear);
        IEnumerable<Post> GetPostsByCategory(string category);
        IEnumerable<Post> GetPostsByTag(string tag);
        Post Find(Guid id);
        Post Find(int year, int month, string urlSlug);
        void Add(Post post);
        void Update(Post post);
        void Delete(Post post);
        void DeleteById(Guid id);
        int CountPostsForCategory(string category);
        int CountPostsForTag(string tag);
        IEnumerable<Post> GetMostViewedPosts(int size);
        IEnumerable<Post> GetHighestPosts(int size);
    }
}
