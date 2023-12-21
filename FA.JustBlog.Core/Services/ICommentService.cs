namespace FA.JustBlog.Core
{
    public interface ICommentService
    {
        IEnumerable<Comment> GetAll();
        Comment Find(Guid id);
        void Add(Comment comment);
        void Add(Guid id, string name, string email, string title, string body);
        void Update(Comment comment);
        void Delete(Comment comment);
        void DeleteById(Guid id);
        IEnumerable<Comment> GetCommentsForPost(Guid postId);
        IEnumerable<Comment> GetCommentsForPost(Post post);
    }
}
