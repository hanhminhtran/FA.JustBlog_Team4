using System.ComponentModel.DataAnnotations;

namespace FA.JustBlog.Website.Models
{
    public class SignInVm
    {
        [Required, DataType(DataType.EmailAddress, ErrorMessage = "Invalid Email.")]
        public string Email{ get; set; }

        [Required, DataType(DataType.Password, ErrorMessage = "Invalid Password.")]
        public string Password { get; set; }
    }
}
