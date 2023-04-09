namespace Data.Models; 

public class PictureDataset {
    public int Id { get; set; }

    public DateTime CreateDate { get; set; }

    public List<PictureDatasetUser> PictureDatasetUsers { get; set; }
}