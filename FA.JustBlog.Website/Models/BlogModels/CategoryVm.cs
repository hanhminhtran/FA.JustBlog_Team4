using FA.JustBlog.Core;
using System.ComponentModel.DataAnnotations;

namespace FA.JustBlog.Website.Models
{
    public class CategoryVm
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Category name is required.")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Url slug is required.")]
        [StringLength(255)]
        public string UrlSlug { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(1024)]
        public string Description { get; set; }

        public virtual IList<Post> Posts { get; set; }
    }
}
