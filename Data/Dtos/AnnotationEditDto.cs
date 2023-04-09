namespace AnnotateAPI.Dtos; 

public class AnnotationEditDto {
    public long Id { get; set; }
    public IEnumerable<Tuple<int, int>> Coordinates { get; set; }
    public string Description { get; set; }
}