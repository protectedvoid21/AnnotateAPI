using Data.Models;

namespace AnnotateAPI.Seeders; 

public class BodyPartTypeSeeder : ISeeder {
    public async Task Seed(AnnotateDbContext dbContext) {
        IEnumerable<string> bodyPartTypeNames = new[] {
            "Liver", "Lungs", "Stomach", "Spleen", "Intestine", "Heart", "Bladder", "Pancreas", "Thyroid"
        };

        var bodyPartsToAdd = bodyPartTypeNames.Except(dbContext.BodyPartTypes.Select(b => b.Name));

        IEnumerable<BodyPartType> bodyParts = bodyPartsToAdd.Select(b => new BodyPartType{ Name = b });

        await dbContext.AddRangeAsync(bodyParts);
        await dbContext.SaveChangesAsync();
    }
}