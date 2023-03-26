using Data.Models;

namespace Services.Annotations; 

public interface IAnnotationService {
    Task AddAsync(string authorId, int pictureId, string description, IEnumerable<Tuple<int, int>> coordinates);

    Task UpdateAsync(int id, string description, IEnumerable<Tuple<int, int>> coordinates);

    Task DeleteAsync(int id);

    Task<IEnumerable<Annotation>> GetAllForPicture(int pictureId);
}