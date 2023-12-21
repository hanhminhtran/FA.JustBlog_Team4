namespace FA.JustBlog.Core
{
    public class TagRepository : GenericRepository<Tag>, ITagRepository
    {
        public TagRepository(JustBlogContext dbContext) : base(dbContext)
        {

        }
    }
}
