
using core.Entites.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager) 
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "bob",
                    Email = "bob@test.com",
                    UserName = "bob@test.com",
                    Address = new Address
                    {
                        FirstName = "bob",
                        LastName = "bobbity",
                        Street = "10 the street",
                        City = "New York",
                        State = "NY",
                        ZipCode = "10100"
                    }

                };
                
                await userManager.CreateAsync(user, "Pa$$w0rd");
            }
        }
    }
}