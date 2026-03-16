using RoshanAPI.Data;
using RoshanAPI.Models;
using BCrypt.Net;

namespace RoshanAPI.Services
{
    public static class SeedData
    {
        public static void Initialize(AppDbContext context)
        {
            if (!context.Users.Any())
            {
                var admin = new User
                {
                    Username = "admin",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin@123"),
                    Role = "Admin"
                };
                context.Users.Add(admin);
            }

            if (!context.Accounts.Any())
            {
                context.Accounts.AddRange(
                    new Account { Name = "Cash", Type = "Asset" },
                    new Account { Name = "Bank", Type = "Asset" },
                    new Account { Name = "Sales", Type = "Income" },
                    new Account { Name = "Rent Expense", Type = "Expense" }
                );
            }

            context.SaveChanges();
        }
    }
}
