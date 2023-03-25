using Data.Models;

namespace AnnotateAPI.Seeders; 

public class BodyPartTypeSeeder : ISeeder {
    public async Task Seed(AnnotateDbContext dbContext, IServiceProvider serviceProvider) {
        IEnumerable<string> bodyPartTypeNames = new[] {
            "Liver", "Lungs", "Stomach", "Spleen", "Intestine", "Heart", "Bladder", "Pancreas", "Thyroid"
        };

        var bodyPartsToAdd = bodyPartTypeNames.Except(dbContext.BodyPartTypes.Select(b => b.Name));

        foreach (var bodyName in bodyPartsToAdd) {
            BodyPartType bodyType = new() {
                Name = bodyName
            };

            await dbContext.AddAsync(bodyType);
        }
    }
}