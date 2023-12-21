namespace FA.JustBlog.Core
{
    public class CommentService : ICommentService
    {
        public IUnitOfWork _unitOfWork { get; set; }

        public CommentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Add(Comment comment)
        {
            _unitOfWork.CommentRepository.Add(comment);
            _unitOfWork.Commit();
        }
        public void Add(Guid id, string name, string email, string title, string body)
        {
            var comment = new Comment()
            {
                Id = id,
                Name = name,
                Email = email,
                CommentHeader = title,
                CommentText = body,
                CommentTime = DateTime.Now,
            };

            _unitOfWork.CommentRepository.Add(comment);
            _unitOfWork.Commit();
        }
        public void Delete(Comment comment)
        {
            _unitOfWork.CommentRepository.Remove(comment);
            _unitOfWork.Commit();
        }
        public void Delete(Guid id)
        {
            _unitOfWork.CommentRepository.Remove(Find(id));
            _unitOfWork.Commit();
        }
        public IEnumerable<Comment> GetAll()
        {
            return _unitOfWork.CommentRepository.GetAll();
        }
        public Comment Find(Guid id)
        {
            return _unitOfWork.CommentRepository.Get(x => x.Id == id);
        }
        public void Update(Comment comment)
        {
            _unitOfWork.CommentRepository.Update(comment);
            _unitOfWork.Commit();
        }
        public IEnumerable<Comment> GetCommentsForPost(Guid postId)
        {
            return _unitOfWork.CommentRepository.GetAll().Where(x => x.PostId == postId);
        }
        public IEnumerable<Comment> GetCommentsForPost(Post post)
        {
            return _unitOfWork.CommentRepository.GetAll().Where(x => x.Post == post);
        }

        public void DeleteById(Guid id)
        {
            _unitOfWork.CommentRepository.Remove(Find(id));
            _unitOfWork.Commit();
        }
    }
}
