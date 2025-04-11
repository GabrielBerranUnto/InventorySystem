using System.Linq;
using InventorySystem.Models.Entities;

namespace InventorySystem.Data
{
    public static class DbInitializer
    {
        public static void Seed(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            // Seed Roles
            if (!context.Roles.Any())
            {
                context.Roles.AddRange(
                    new Role { RoleName = "Admin" },
                    new Role { RoleName = "Staff" }
                );
                context.SaveChanges();
            }

            // Seed Admin User
            if (!context.Users.Any())
            {
                var adminRole = context.Roles.First(r => r.RoleName == "Admin");

                context.Users.Add(new User
                {
                    Username = "admin",
                    PasswordHash = Hash("admin123"), // Simple demo hash
                    RoleID = adminRole.RoleID
                });
                context.SaveChanges();
            }
        }

        // 🔐 Simple SHA256 password hashing
        private static string Hash(string input)
        {
            using (var sha = System.Security.Cryptography.SHA256.Create())
            {
                var bytes = System.Text.Encoding.UTF8.GetBytes(input);
                var hash = sha.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
    }
}
