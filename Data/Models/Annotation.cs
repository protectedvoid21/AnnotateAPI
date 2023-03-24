using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace AnnotateAPI.Models;

public class Annotation {
    public int Id { get; set; }
    
    public string AuthorId { get; set; }
    public AppUser Author { get; set; }
    
    public Polygon Polygon { get; set; }

    public int PictureId { get; set; }
    public Picture Picture { get; set; }
    
    public string Description { get; set; }
}