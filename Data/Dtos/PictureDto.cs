namespace AnnotateAPI.Dtos; 

public class PictureDto {
    public string Name { get; set; }

    public string? Description { get; set; }

    public int BodyPartTypeId { get; set; }
}