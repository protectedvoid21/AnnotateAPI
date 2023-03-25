namespace Services.Pictures; 

public interface IPictureService {
    Task AddAsync(string name, int bodyPartTypeId);
}