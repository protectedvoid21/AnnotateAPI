namespace AnnotateAPI.Dtos; 

public class AnnotationDto {
    public string AuthorId { get; set; }
    public IEnumerable<Tuple<int, int>> Coordinates { get; set; }
    public string Description { get; set; }
}