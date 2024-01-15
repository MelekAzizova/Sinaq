using Microsoft.AspNetCore.Identity;

namespace Blog.Models
{
    public class AppUser:IdentityUser
    {
        public string FullName { get; set; }
        public override string PhoneNumber { get ; set ; }
        public override bool PhoneNumberConfirmed { get ; set ; }
    }
}
