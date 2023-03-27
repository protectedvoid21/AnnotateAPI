using Data.Models;

namespace Services.Pictures; 

public interface IPictureService {
    Task<bool> AddAsync(string name, int bodyPartTypeId);

    Task<Picture> Get(int id);

    Task<bool> UpdateAsync(int id, string name, int bodyPartTypeId);

    Task<bool> DeleteAsync(int id);
}