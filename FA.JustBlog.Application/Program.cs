using FA.JustBlog.Core;
using Microsoft.EntityFrameworkCore;

var optionsBuilder = new DbContextOptionsBuilder<JustBlogContext>();
optionsBuilder.UseSqlServer("server=LAPTOP-6UKDON56;database=JustBlogDb;Trusted_Connection=true;TrustServerCertificate=true;");

using (JustBlogContext dbContext = new JustBlogContext(optionsBuilder.Options))
{
    try
    {
        IUnitOfWork unitOfWork = new UnitOfWork(dbContext);
        IPostService postService = new PostService(unitOfWork);
        ITagService authorService = new TagService(unitOfWork);
        ICategoryService categoryService = new CategoryService(unitOfWork);
        ICommentService commentService = new CommentService(unitOfWork);
        dbContext.Database.EnsureCreated();
        SeedData seedData = new SeedData();
        seedData.Seed(dbContext);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}
