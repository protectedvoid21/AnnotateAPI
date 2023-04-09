namespace Data.Models; 

public class AnnotationStatus {
    public int Id { get; set; }
    
    public int PictureId { get; set; }
    public Picture Picture { get; set; }

    public AnnotationStatusType StatusType { get; set; }
}