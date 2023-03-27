using Data.Models;
using Microsoft.AspNetCore.Identity;

namespace AnnotateAPI.Seeders;

public class UserSeeder : ISeeder {
    public async Task Seed(AnnotateDbContext dbContext) {
        IEnumerable<AppUser> users = new[] {
            new AppUser { Email = "test@asd.com", UserName = "User1" },
            new AppUser { Email = "other@asd.com", UserName = "User2" },
            new AppUser { Email = "expert@asd.com", UserName = "User3" }
        };

        //TODO: ADDING USERS
    }
}