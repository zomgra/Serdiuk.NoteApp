using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Serdiuk.NoteApp.Infrastructure.Persistance.Auth
{
    public static class AuthDbContextSeed
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetService<AuthDbContext>();
            context.Database.EnsureCreated(); // добавьте эту строку

            var userManager = scope.ServiceProvider.GetService<UserManager<IdentityUser>>();

            if (context.Users.Any())
            {
                return;
            }
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var res = await roleManager.CreateAsync(new IdentityRole { Name = "Admin", NormalizedName = "Admin".ToUpper() });
            var developer1 = new IdentityUser
            {
                Email = "notesadmin@yopmail.com",
                NormalizedEmail = "NOTESADMIN@YOPMAIL.COM",
                UserName = "notesadmin@yopmail.com",
                NormalizedUserName = "NOTESADMIN@YOPMAIL.COM",
                PhoneNumber = "+38000000000",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
            };
            
            if (!context.Users.Any(u => u.UserName == developer1.UserName))
            {
                //var password = new PasswordHasher<IdentityUser>();
                //var hashed = password.HashPassword(developer1, "123qwerty");
                //developer1.PasswordHash = hashed;

                var result = await userManager.CreateAsync(developer1, "123qwerty");
                if (result.Succeeded)
                {

                    await context.SaveChangesAsync();
                }
                var roleAdded = await userManager!.AddToRoleAsync(developer1, "Admin");
                if (roleAdded.Succeeded)
                {
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
