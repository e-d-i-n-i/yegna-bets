using Microsoft.AspNetCore.Identity;
using YEGNA_BETS.Constants;
using YEGNA_BETS.Models.Domain;

namespace YEGNA_BETS_APP.Data
{
    public static class DbSeeder
    {
        public static async Task SeedRolesAndAdminAsync(IServiceProvider service)
        {
            //Seed Roles
            var userManager = service.GetService<UserManager<ApplicationUser>>();
            var roleManager = service.GetService<RoleManager<IdentityRole>>();
            await roleManager.CreateAsync(new IdentityRole(Roles.Administrator.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.User.ToString()));

            // Creating Admin
            var user = new ApplicationUser
            {
                UserName = "Admin@gmail.com",
                Email = "Admin@gmail.com",
                FullName = "Edini Amare",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                RegistrationDate = DateTime.Today,
            };
            var userInDb = await userManager.FindByEmailAsync(user.Email);
            if (userInDb == null)
            {
                await userManager.CreateAsync(user, "Admin@123");
                await userManager.AddToRoleAsync(user, Roles.Administrator.ToString());
            }
        }

    }
}
