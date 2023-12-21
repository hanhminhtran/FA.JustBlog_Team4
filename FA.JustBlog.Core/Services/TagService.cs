namespace FA.JustBlog.Core
{
    public class TagService : ITagService
    {
        public IUnitOfWork _unitOfWork { get; set; }

        public TagService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Tag tag)
        {
            _unitOfWork.TagRepository.Add(tag);
            _unitOfWork.Commit();
        }

        public void Delete(Tag tag)
        {
            _unitOfWork.TagRepository.Remove(tag);
            _unitOfWork.Commit();
        }

        public void DeleteById(Guid id)
        {
            _unitOfWork.TagRepository.Remove(Find(id));
            _unitOfWork.Commit();
        }

        public IEnumerable<Tag> GetAll()
        {
            return _unitOfWork.TagRepository.GetAll();
        }

        public Tag Find(Guid id)
        {
            return _unitOfWork.TagRepository.Get(x => x.Id == id);
        }

        public void Update(Tag tag)
        {
            _unitOfWork.TagRepository.Update(tag);
            _unitOfWork.Commit();
        }

        public Tag GetTagByUrlSlug(string urlSlug)
        {
            return _unitOfWork.TagRepository.Get(x => x.UrlSlug == urlSlug);
        }
        public IEnumerable<Tag> GetTopTags()
        {
            return _unitOfWork.TagRepository.GetAll().OrderBy(x => x.Name).Take(3);
        }
    }
}