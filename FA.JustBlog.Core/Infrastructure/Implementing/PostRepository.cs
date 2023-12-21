namespace FA.JustBlog.Core
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public PostRepository(JustBlogContext dbContext) : base(dbContext)
        {

        }
    }
}
