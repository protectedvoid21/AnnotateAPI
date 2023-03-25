namespace Data.Models;

public class Annotation {
    public int Id { get; set; }
    
    public string AuthorId { get; set; }
    public AppUser Author { get; set; }
    
    public List<Coordinate> Coordinates { get; set; }

    public int PictureId { get; set; }
    public Picture Picture { get; set; }
    
    public string Description { get; set; }
}