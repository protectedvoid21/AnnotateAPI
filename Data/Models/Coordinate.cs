namespace Data.Models; 

public class Coordinate {
    public long Id { get; set; }
    
    public long AnnotationId { get; set; }
    public Annotation Annotation { get; set; }

    public int X { get; set; }
    public int Y { get; set; }
}