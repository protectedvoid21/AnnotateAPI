namespace AnnotateAPI.Dtos; 

public class PictureDatasetAddDto {
    public List<int> PictureIds { get; set; }
    public List<string> UserIds { get; set; }
}