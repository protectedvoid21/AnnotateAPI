using Data.Models;
using Microsoft.AspNetCore.Identity;

namespace AnnotateAPI.Seeders;

public class UserSeeder : ISeeder {
    public async Task Seed(AnnotateDbContext dbContext, IServiceProvider serviceProvider) {
        var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();

        IEnumerable<AppUser> users = new[] {
            new AppUser { Email = "test@asd.com", UserName = "User1" },
            new AppUser { Email = "other@asd.com", UserName = "User2" },
            new AppUser { Email = "expert@asd.com", UserName = "User3" }
        };

        foreach (var user in users) {
            if (await userManager.FindByEmailAsync(user.Email) == null) {
                await userManager.CreateAsync(user, user.UserName);
            }
        }
    }
}