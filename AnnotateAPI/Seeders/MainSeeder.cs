namespace AnnotateAPI.Seeders; 

public class MainSeeder : ISeeder {
    public async Task Seed(AnnotateDbContext dbContext, IServiceProvider serviceProvider) {
        if(dbContext == null) {
            throw new ArgumentNullException(nameof(dbContext));
        }

        if(serviceProvider == null) {
            throw new ArgumentNullException(nameof(serviceProvider));
        }

        ISeeder[] seeders = {
            new UserSeeder(),
            new BodyPartTypeSeeder(),
            new PictureSeeder(),
        };

        foreach (var seeder in seeders) {
            await seeder.Seed(dbContext, serviceProvider);
            await dbContext.SaveChangesAsync();
        }
    }
}