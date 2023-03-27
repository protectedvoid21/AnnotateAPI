namespace AnnotateAPI.Seeders; 

public interface ISeeder {
    Task Seed(AnnotateDbContext dbContext);
}