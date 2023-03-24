namespace AnnotateAPI.Seeders; 

public interface ISeeder {
    public void Seed(AnnotateDbContext dbContext, IServiceProvider serviceProvider);
}