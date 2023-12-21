namespace FA.JustBlog.Core
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(JustBlogContext dbContext) : base(dbContext)
        {

        }
    }
}
