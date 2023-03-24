namespace Services.Annotation; 

public interface IAnnotationService {
    Task AddAsync(string authorId, string description, IEnumerable<Tuple<int, int>> coordinates);
}