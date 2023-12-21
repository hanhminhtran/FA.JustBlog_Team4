using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FA.JustBlog.Core
{
    public class Comment : BaseEntity
    {
        [Required(ErrorMessage = "Comment name is required.")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [StringLength(255)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Comment header is required.")]
        [StringLength(255)]
        public string CommentHeader { get; set; }

        [Required(ErrorMessage = "Comment text is required.")]
        [StringLength(1024)]
        public string CommentText { get; set; }

        public DateTime CommentTime { get; set; }

        [ForeignKey("Post")]
        public Guid PostId { get; set; }
        public Post Post { get; set; }
    }
}
