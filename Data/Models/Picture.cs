namespace Data.Models; 

public class Picture {
    public int Id { get; set; }

    public string Name { get; set; }

    public DateTime CreatedDate { get; set; }

    public int BodyPartTypeId { get; set; }

    public BodyPartType BodyPartType { get; set; }
}