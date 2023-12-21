namespace FA.JustBlog.Core
{
    public class CategoryService : ICategoryService
    {
        public IUnitOfWork _unitOfWork { get; set; }
        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Add(Category category)
        {
            _unitOfWork.CategoryRepository.Add(category);
            _unitOfWork.Commit();
        }
        public void Delete(Category category)
        {
            _unitOfWork.CategoryRepository.Remove(category);
            _unitOfWork.Commit();
        }
        public void DeleteById(Guid id) 
        {
            _unitOfWork.CategoryRepository.Remove(Find(id));
            _unitOfWork.Commit();
        }
        public IEnumerable<Category> GetAll()
        {
            return _unitOfWork.CategoryRepository.GetAll();
        }
        public Category Find(Guid id)
        {
            return _unitOfWork.CategoryRepository.Get(x => x.Id == id);
        }
        public void Update(Category category)
        {
            _unitOfWork.CategoryRepository.Update(category);
            _unitOfWork.Commit();
        }
    }
}
