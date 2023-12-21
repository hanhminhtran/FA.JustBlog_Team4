using Microsoft.AspNetCore.Identity;
namespace FA.JustBlog.Website.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
    }
}