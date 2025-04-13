using System;
using System.Collections.Generic;
using System.Linq;
using UMBRAPage.Models;
using BCrypt.Net;

namespace UMBRAPage.Data
{
    public static class AdminUserSeeder
    {
        public static void Seed(ApplicationDbContext db)
        {
            if (db.AdminUsers.Any())
                return;

            var users = new List<AdminUser>();

            for (int i = 1; i <= 5; i++)
            {
                var username = Environment.GetEnvironmentVariable($"AdminUser{i}__Username");
                var password = Environment.GetEnvironmentVariable($"AdminUser{i}__Password");

                if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
                {
                    users.Add(new AdminUser
                    {
                        Username = username,
                        PasswordHash = BCrypt.Net.BCrypt.HashPassword(password)
                    });
                }
            }

            db.AdminUsers.AddRange(users);
            db.SaveChanges();
        }
    }
}
