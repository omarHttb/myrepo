using Microsoft.AspNetCore.Identity;

namespace core.Entites.Identity
{
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }
        public Address Address { get; set; }
    }
}