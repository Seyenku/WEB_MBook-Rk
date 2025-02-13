using Microsoft.AspNetCore.Identity;
using MBook_Rk.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace MBook_Rk
{
    public class SeedRoles
    {
        public static async Task InitializeRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<CustomRoleManager>();
            string[] roles = { "Admin", "User", "Moderator" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    Console.WriteLine($"DEBUG: Создание роли {role}...");
                    await roleManager.CreateAsync(new ApplicationRole { Name = role, NormalizedName = role.ToUpper() });
                }
                else
                {
                    Console.WriteLine($"DEBUG: Роль {role} уже существует.");
                }
            }
        }

    }
}