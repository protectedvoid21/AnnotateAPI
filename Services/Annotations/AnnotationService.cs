using AnnotateAPI;
using Data.Models;
using NetTopologySuite.Geometries;

namespace Services.Annotations; 

public class AnnotationService : IAnnotationService {
    private readonly AnnotateDbContext dbContext;

    public AnnotationService(AnnotateDbContext dbContext) {
        this.dbContext = dbContext;
    }

    public async Task AddAsync(string authorId, string description, IEnumerable<Tuple<int, int>> coordinates) {
        LinearRing ring = new(coordinates.Select(c => new Coordinate(c.Item1, c.Item2)).ToArray());
        
        Annotation annotation = new() {
            AuthorId = authorId,
            Description = description,
            Polygon = new Polygon(ring)
        };

        await dbContext.AddAsync(annotation);
        await dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Annotation>> GetAllForPicture(int pictureId) {
        return dbContext.Annotations.Where(a => a.PictureId == pictureId);
    }
}