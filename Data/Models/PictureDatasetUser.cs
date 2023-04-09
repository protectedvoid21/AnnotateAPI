namespace Data.Models; 

public class PictureDatasetUser {
    public int Id { get; set; }
    
    public int PictureId { get; set; }
    public Picture Picture { get; set; }

    public string AnnotatorId { get; set; }
    public AppUser Annotator { get; set; }

    public int PictureDatasetId { get; set; }
    public PictureDataset PictureDataset { get; set; }

    public AnnotationStatus AnnotationStatus { get; set; }
}