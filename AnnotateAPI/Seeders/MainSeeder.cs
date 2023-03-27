namespace AnnotateAPI.Seeders; 

public class MainSeeder : ISeeder {
    public async Task Seed(AnnotateDbContext dbContext) {
        if(dbContext == null) {
            throw new ArgumentNullException(nameof(dbContext));
        }

        ISeeder[] seeders = {
            new UserSeeder(),
            new BodyPartTypeSeeder(),
            new PictureSeeder(),
        };

        foreach (var seeder in seeders) {
            await seeder.Seed(dbContext);
            await dbContext.SaveChangesAsync();
        }
    }
}