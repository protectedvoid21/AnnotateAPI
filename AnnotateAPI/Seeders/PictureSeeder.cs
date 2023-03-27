﻿using Data.Models;

namespace AnnotateAPI.Seeders; 

public class PictureSeeder : ISeeder {
    public async Task Seed(AnnotateDbContext dbContext) {
        IEnumerable<Picture> pictures = new[] {
            new Picture { Name = "Liver1231231"  ,BodyPartTypeId = 1, Description = "Liver picture, very bad"},
            new Picture { Name = "Left_lung84024"  ,BodyPartTypeId = 2 },
            new Picture { Name = "Right_lung17593"  ,BodyPartTypeId = 2, Description = "Heavily affected"},
            new Picture { Name = "Stomach99912 #1"  ,BodyPartTypeId = 3, Description = "Probably stomach cancer"},
            new Picture { Name = "Stomach13156 #2"  ,BodyPartTypeId = 3 },
            new Picture { Name = "Stomach89754 #3" ,BodyPartTypeId = 3 },
        };

        var picturesToAdd = pictures.Except(dbContext.Pictures);

        await dbContext.AddRangeAsync(picturesToAdd);
        await dbContext.SaveChangesAsync();
    }
}