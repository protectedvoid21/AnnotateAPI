namespace Data.Models; 

public class PictureDataset {
    public int Id { get; set; }

    public DateTime CreateDate { get; set; }

    public IEnumerable<Picture> Picture { get; set; }
}