using System.ComponentModel.DataAnnotations;

namespace FA.JustBlog.Core
{
    public class Tag : BaseEntity
    {
        [Required(ErrorMessage = "Tag name is required.")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Url slug is required.")]
        [StringLength(255)]
        public string UrlSlug { get; set; }

        [StringLength(1024)]
        public string? Description { get; set; }
        public int Count { get; set; }

        public virtual IList<PostTagMap> PostTagMaps { get; set; }
    }
}