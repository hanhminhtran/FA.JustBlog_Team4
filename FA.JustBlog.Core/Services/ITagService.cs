namespace FA.JustBlog.Core
{
    public interface ITagService
    {
        IEnumerable<Tag> GetAll();
        Tag Find(Guid id);
        void Add(Tag tag);
        void Update(Tag tag);
        void Delete(Tag tag);
        void DeleteById(Guid id);
        Tag GetTagByUrlSlug(string urlSlug);
        IEnumerable<Tag> GetTopTags();
    }
}