using AnnotateAPI;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Services.Pictures; 

public class PictureService : IPictureService {
    private readonly AnnotateDbContext dbContext;

    public PictureService(AnnotateDbContext dbContext) {
        this.dbContext = dbContext;
    }

    public async Task AddAsync(string name, int bodyPartTypeId) {
        if (await dbContext.Pictures.AnyAsync(p => p.Name.Equals(name))) {
            return;
        }

        Picture picture = new() {
            Name = name,
            BodyPartTypeId = bodyPartTypeId,
            CreatedDate = DateTime.Now
        };

        await dbContext.AddAsync(picture);
        await dbContext.SaveChangesAsync();
    }
}