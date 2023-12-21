using System.ComponentModel.DataAnnotations;

namespace FA.JustBlog.Core
{
    public class Category : BaseEntity
    {
        [Required(ErrorMessage = "Category name is required.")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Url slug is required.")]
        [StringLength(255)]
        public string UrlSlug { get; set; }

        [StringLength(1024)]
        public string? Description { get; set; }

        public virtual IList<Post> Posts { get; set; }
    }
}