using AnnotateAPI;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Services.Annotations; 

public class AnnotationService : IAnnotationService {
    private readonly AnnotateDbContext dbContext;

    public AnnotationService(AnnotateDbContext dbContext) {
        this.dbContext = dbContext;
    }

    public async Task AddAsync(string authorId, int pictureId, string description, IEnumerable<Tuple<int, int>> coordinates) {
        Annotation annotation = new() {
            AuthorId = authorId,
            PictureId = pictureId,
            Description = description,
        };

        annotation.Coordinates = coordinates.Select(c => new Coordinate {
            Annotation = annotation,
            X = c.Item1,
            Y = c.Item2,
        }).ToList();

        await dbContext.AddAsync(annotation);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(int id, string description, IEnumerable<Tuple<int, int>> coordinates) {
        Annotation annotation = await dbContext.Annotations.FindAsync(id);

        if (annotation == null) {
            return;
        }

        annotation.Description = description;
        dbContext.RemoveRange(annotation.Coordinates);

        annotation.Coordinates = coordinates.Select(c => new Coordinate{AnnotationId = id, X = c.Item1, Y = c.Item2}).ToList();

        dbContext.Update(annotation);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id) {
        Annotation annotation = await dbContext.Annotations.FindAsync(id);

        if(annotation == null) {
            return;
        }

        dbContext.Remove(annotation);
        await dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Annotation>> GetAllForPicture(int pictureId) {
        return dbContext.Annotations.Where(a => a.PictureId == pictureId)
            .Include(a => a.Coordinates);
    }
}