using AnnotateAPI;
using Data.Models;

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

    public async Task<IEnumerable<Annotation>> GetAllForPicture(int pictureId) {
        return dbContext.Annotations.Where(a => a.PictureId == pictureId);
    }
}