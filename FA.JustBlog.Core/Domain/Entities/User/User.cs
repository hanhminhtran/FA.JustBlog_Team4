using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FA.JustBlog.Core
{
    public class User
    {
        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [StringLength(255)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [StringLength(255)]
        [DataType(DataType.EmailAddress, ErrorMessage ="Invalid Email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(255)]
        [DataType(DataType.Password, ErrorMessage = "Invalid Password.")]
        public string Password { get; set; }

        [NotMapped]
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
