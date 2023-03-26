namespace AnnotateAPI.Dtos; 

public class AnnotationEditDto {
    public int Id { get; set; }
    public IEnumerable<Tuple<int, int>> Coordinates { get; set; }
    public string Description { get; set; }
}