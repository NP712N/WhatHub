using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Portal.Domain.Core;
using Portal.Domain.Core.Auth;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Infrastructure.EF
{
    public class ApplicationDbContextSeed
    {
        public static void SeedAsync(IApplicationBuilder applicationBuilder)
        {
            using var serviceScope = applicationBuilder.ApplicationServices.CreateScope();
            var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

            #region Seed Super User

            string[] roles = new string[] { "Administrator", "Manager", "Staff", "User" };
            foreach (string role in roles)
            {
                var roleStore = new RoleStore<IdentityRole>(context);

                if (!context.Roles.Any(r => r.Name == role))
                {
                    var newRole = new IdentityRole
                    {
                        Name = role,
                        NormalizedName = role.ToUpper()
                    };
                    roleStore.CreateAsync(newRole).Wait();
                }
            }
            //context.SaveChangesAsync().Wait();

            var user = new User
            {
                FirstName = "Super",
                LastName = "Admin",
                Email = "xxxx@example.com",
                NormalizedEmail = "XXXX@EXAMPLE.COM",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                PhoneNumber = "+111111111111",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            if (!context.Users.Any(u => u.UserName == user.UserName))
            {
                var password = new PasswordHasher<User>();
                var hashed = password.HashPassword(user, "Abc#1234");
                user.PasswordHash = hashed;

                var userStore = new UserStore<User>(context);
                var result = userStore.CreateAsync(user);
            }

            AssignRolesAsync(serviceScope.ServiceProvider, user.Email, roles).Wait();

            #endregion Seed Super User

            #region Seed Posts

            var postDbSet = context.Set<Post>();
            if (!postDbSet.Any())
            {
                for (int i = 0; i < 3; i++)
                {
                    postDbSet.Add(new Post
                    {
                        Title = $"Test {i}",
                        Content = $"Test {i}",
                        Image = "https://i.pinimg.com/236x/c5/3e/11/c53e110ac70e3555950057eb92334f66.jpg"
                    });
                }
            }

            #endregion Seed Posts

            context.SaveChangesAsync().Wait();
        }

        private static async Task<IdentityResult> AssignRolesAsync(IServiceProvider serviceScope, string email, string[] roles)
        {
            UserManager<User> _userManager = serviceScope.GetService<UserManager<User>>();
            User user = await _userManager.FindByEmailAsync(email);
            var result = await _userManager.AddToRolesAsync(user, roles);

            return result;
        }
    }
}