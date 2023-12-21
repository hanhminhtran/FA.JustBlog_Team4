using FA.JustBlog.Core;

namespace FA.JustBlog.Website.Models
{
    public class PostTagMapVm
    {
        public Guid? PostId { get; set; }
        public Post? Post { get; set; }
        public Guid? TagId { get; set; }
        public Tag? Tag { get; set; }
    }
}
