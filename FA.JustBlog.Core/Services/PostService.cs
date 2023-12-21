namespace FA.JustBlog.Core
{
    public class PostService : IPostService
    {
        public IUnitOfWork _unitOfWork { get; set; }

        public PostService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Add(Post Post)
        {
            _unitOfWork.PostRepository.Add(Post);
            _unitOfWork.Commit();
        }
        public void Delete(Post Post)
        {
            _unitOfWork.PostRepository.Remove(Post);
            _unitOfWork.Commit();
        }
        public void DeleteById(Guid id)
        {
            _unitOfWork.PostRepository.Remove(Find(id));
            _unitOfWork.Commit();
        }
        public IEnumerable<Post> GetAll()
        {
            return _unitOfWork.PostRepository.GetAll();
        }
        public IEnumerable<Post> GetPublishedPosts()
        {
            return _unitOfWork.PostRepository.GetAll().Where(x => x.Published == true);
        }
        public IEnumerable<Post> GetUnpublishedPosts()
        {
            return _unitOfWork.PostRepository.GetAll().Where(x => x.Published == false);
        }
        public IEnumerable<Post> GetLatestPost(int size)
        {
            return _unitOfWork.PostRepository.GetAll().OrderByDescending(x => x.PostedOn).Take(size);
        }
        public IEnumerable<Post> GetPostsByMonth(DateTime monthYear)
        {
            return _unitOfWork.PostRepository.GetAll().Where(x => x.PostedOn.Month == monthYear.Month && x.PostedOn.Year == monthYear.Year);
        }
        public IEnumerable<Post> GetPostsByCategory(string category)
        {
            return _unitOfWork.PostRepository.GetAll().Where(x => x.Category.Name == category);
        }
        public IEnumerable<Post> GetPostsByTag(string tag)
        {
            return _unitOfWork.PostRepository.GetAll().Where(x => x.PostTagMaps.Any(i => i.Tag.Name == tag));
        }
        public Post Find(Guid id)
        {
            return _unitOfWork.PostRepository.Get(x => x.Id == id);
        }
        public Post Find(int year, int month, string urlSlug)
        {
            return _unitOfWork.PostRepository.Get(x => x.PostedOn.Month == month && x.PostedOn.Year == year && x.UrlSlug == urlSlug);
        }
        public void Update(Post Post)
        {
            _unitOfWork.PostRepository.Update(Post);
            _unitOfWork.Commit();
        }
        public int CountPostsForCategory(string category)
        {
            return _unitOfWork.PostRepository.GetAll().Count(x => x.Category.Name == category);
        }
        public int CountPostsForTag(string tag)
        {
            return _unitOfWork.PostRepository.GetAll().Count(x => x.PostTagMaps.Any(i => i.Tag.Name == tag));
        }
        public IEnumerable<Post> GetMostViewedPosts(int size)
        {
            return _unitOfWork.PostRepository.GetAll().OrderByDescending(x => x.ViewCount).Take(size);
        }
        public IEnumerable<Post> GetHighestPosts(int size)
        {
            return _unitOfWork.PostRepository.GetAll().OrderByDescending(x => x.Rate).Take(size);
        }
    }
}
