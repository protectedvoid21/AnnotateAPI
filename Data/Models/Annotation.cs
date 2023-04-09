using System.ComponentModel.DataAnnotations;

namespace Data.Models;

public class Annotation {
    public long Id { get; set; }
    
    public string Description { get; set; }
    
    public string AuthorId { get; set; }
    public AppUser Author { get; set; }
    
    public List<Coordinate> Coordinates { get; set; }

    public int PictureId { get; set; }
    public Picture Picture { get; set; }

    [Range(1, 100)]
    public int SurenessPercent { get; set; }
}