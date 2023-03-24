namespace AnnotateAPI.Seeders; 

public class MainSeeder : ISeeder {
    public void Seed(AnnotateDbContext dbContext, IServiceProvider serviceProvider) {
        ISeeder[] seeders = {
            new MainSeeder(),
        };

        foreach (var seeder in seeders) {
            seeder.Seed(dbContext, serviceProvider);
        }
    }
}