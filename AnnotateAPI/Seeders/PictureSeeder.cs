using Data.Models;
using Services.Pictures;

namespace AnnotateAPI.Seeders; 

public class PictureSeeder : ISeeder {
    public async Task Seed(AnnotateDbContext dbContext, IServiceProvider serviceProvider) {
        var pictureService = serviceProvider.GetRequiredService<IPictureService>();

        IEnumerable<Picture> pictures = new[] {
            new Picture { Name = "Liver1231231"  ,BodyPartTypeId = 1 },
            new Picture { Name = "Left_lung84024"  ,BodyPartTypeId = 2 },
            new Picture { Name = "Right_lung17593"  ,BodyPartTypeId = 2 },
            new Picture { Name = "Stomach99912 #1"  ,BodyPartTypeId = 3 },
            new Picture { Name = "Stomach13156 #2"  ,BodyPartTypeId = 3 },
            new Picture { Name = "Stomach89754 #3" ,BodyPartTypeId = 3 },
        };

        foreach (var picture in pictures) {
            await pictureService.AddAsync(picture.Name, picture.BodyPartTypeId);
        }
    }
}