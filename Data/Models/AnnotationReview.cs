namespace Data.Models; 

public class AnnotationReview {
    public int Id { get; set; }

    public AppUser Expert { get; set; }
    public string ExpertId { get; set; }

    public Annotation Annotation { get; set; }
    public long AnnotationId { get; set; }
}