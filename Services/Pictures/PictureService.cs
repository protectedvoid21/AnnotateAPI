using AnnotateAPI;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Services.Pictures; 

public class PictureService : IPictureService {
    private readonly AnnotateDbContext dbContext;

    public PictureService(AnnotateDbContext dbContext) {
        this.dbContext = dbContext;
    }

    public async Task AddAsync(string name, int bodyPartTypeId) {
        
    }

    public async 
}