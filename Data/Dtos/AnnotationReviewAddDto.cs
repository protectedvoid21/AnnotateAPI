namespace AnnotateAPI.Dtos; 

public class AnnotationReviewAddDto {
    public string Description { get; set; }
    public string ExpertId { get; set; }
    public long AnnotationId { get; set; }
}