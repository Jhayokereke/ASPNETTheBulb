using Microsoft.AspNetCore.Identity;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public static class Seed
    {
        public static async Task PreSeeder(AppDBContext db, RoleManager<IdentityRole> roleMangr, UserManager<AppUser> userMangr)
        {
            List<string> roles = new List<string> { "Admin", "User" };

            db.Database.EnsureCreated();

            if (!roleMangr.Roles.Any())
            {
                foreach (var role in roles)
                {
                    await roleMangr.CreateAsync(new IdentityRole(role));
                }
            }


            var user = await userMangr.FindByEmailAsync("jhay@thebulb.com");
            if (user == null)
            {
                var admin = new AppUser
                {
                    Email = "jhay@thebulb.com",
                    UserName = "jhay@thebulb.com",
                    FirstName = "Chukwuemeka",
                    LastName = "Okereke"
                };
                await userMangr.CreateAsync(admin, "HavardNativeDoctor");

                await userMangr.AddToRoleAsync(admin, "Admin");

                await userMangr.AddClaimsAsync(admin, new List<Claim> {
                                                    new Claim("Register class", "Register class"),
                                                    new Claim("Delete class", "Delete class")
                                                });
            }
        }
    }
}
