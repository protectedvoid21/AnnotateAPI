namespace Data.Models; 

public class Coordinate {
    public int Id { get; set; }
    
    public int AnnotationId { get; set; }
    public Annotation Annotation { get; set; }

    public int X { get; set; }
    public int Y { get; set; }
}