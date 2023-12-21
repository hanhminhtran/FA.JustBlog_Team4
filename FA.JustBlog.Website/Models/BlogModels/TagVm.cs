using FA.JustBlog.Core;
using System.ComponentModel.DataAnnotations;

namespace FA.JustBlog.Website.Models
{
    public class TagVm
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Tag name is required.")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Url slug is required.")]
        [StringLength(255)]
        public string UrlSlug { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(1024)]
        public string Description { get; set; }

        public int Count { get; set; }

        public IList<PostTagMap> PostTagMaps { get; set; }
    }
}
