namespace FA.JustBlog.Core
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(JustBlogContext dbContext) : base(dbContext)
        {

        }
    }
}
