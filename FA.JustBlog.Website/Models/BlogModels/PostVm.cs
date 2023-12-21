using FA.JustBlog.Core;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FA.JustBlog.Website.Models
{
    public class PostVm
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(255)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Short description is required.")]
        [StringLength(255)]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = "Post content is required.")]
        public string PostContent { get; set; }

        [Required(ErrorMessage = "Url slug is required.")]
        [StringLength(255)]
        public string UrlSlug { get; set; }

        public bool Published { get; set; }

        public DateTime PostedOn { get; set; }

        public DateTime? Modified { get; set; }

        public int ViewCount { get; set; }

        public int RateCount { get; set; }

        public int TotalRate { get; set; }

        [NotMapped]
        public decimal Rate => RateCount == 0 ? 0 : (decimal)TotalRate / RateCount;

        public Guid? CategoryId { get; set; }
        public string? CategoryName { get; set; }

        public Guid? TagId { get; set; }
        public string? TagName { get; set; }

        public Category? Category { get; set; }

        public IList<PostTagMap>? PostTagMaps { get; set; }
    }
}
