namespace FA.JustBlog.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly JustBlogContext _dbContext;
        private ICategoryRepository _categoryRepository;
        private IPostRepository _postRepository;
        private ITagRepository _tagRepository;
        private ICommentRepository _commentRepository;

        public UnitOfWork(JustBlogContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ICategoryRepository CategoryRepository => _categoryRepository ?? new CategoryRepository(_dbContext);
        public IPostRepository PostRepository => _postRepository ?? new PostRepository(_dbContext);
        public ITagRepository TagRepository => _tagRepository ?? new TagRepository(_dbContext);
        public ICommentRepository CommentRepository => _commentRepository ?? new CommentRepository(_dbContext);

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Rollback()
        {
            _dbContext.Dispose();
        }

        public async Task RollbackAsync()
        {
            await _dbContext.DisposeAsync();
        }
    }
}
