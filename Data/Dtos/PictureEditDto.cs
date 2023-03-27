namespace AnnotateAPI.Dtos; 

public class PictureEditDto {
    public int Id { get; set; }

    public string Name { get; set; }

    public string? Description { get; set; }

    public int BodyPartTypeId { get; set; }
}