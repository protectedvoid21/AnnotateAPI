using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AnnotateAPI.Seeders;

public class UserSeeder : ISeeder {
    public async Task Seed(AnnotateDbContext dbContext) {
        IEnumerable<AppUser> users = new[] {
            new AppUser { Email = "test@asd.com", UserName = "User1", PasswordHash = "Password"},
            new AppUser { Email = "other@asd.com", UserName = "User2", PasswordHash = "Password"},
            new AppUser { Email = "expert@asd.com", UserName = "User3", PasswordHash = "Password"}
        };

        foreach (var user in users) {
            if (!await dbContext.Users.AnyAsync(u => u.Email.Equals(user.Email))) {
                await dbContext.AddAsync(user);
            }
        }

        await dbContext.SaveChangesAsync();
    }
}