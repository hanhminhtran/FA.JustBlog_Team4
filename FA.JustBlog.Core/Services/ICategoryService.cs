namespace FA.JustBlog.Core
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAll();
        Category Find(Guid id);
        void Add(Category category);
        void Update(Category category);
        void Delete(Category category);
        void DeleteById(Guid id);
    }
}
