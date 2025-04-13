using System;
using System.Collections.Generic;
using System.IO;
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

            for (int i = 1; i <= 2; i++)
            {
                // Try to read from secret file
                string baseKey = $"AdminUser{i}__";
                string userPath = $"/etc/secrets/{baseKey}Username";
                string passPath = $"/etc/secrets/{baseKey}Password";

                string username = File.Exists(userPath)
                    ? File.ReadAllText(userPath).Trim()
                    : Environment.GetEnvironmentVariable($"{baseKey}Username");

                string password = File.Exists(passPath)
                    ? File.ReadAllText(passPath).Trim()
                    : Environment.GetEnvironmentVariable($"{baseKey}Password");

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
