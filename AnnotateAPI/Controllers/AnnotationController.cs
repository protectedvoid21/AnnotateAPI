using AnnotateAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AnnotateAPI.Controllers;

[ApiController]
[Route("annotation/")]
public class AnnotationController : ControllerBase {
    private readonly AnnotateDbContext dbContext;

    public AnnotationController(AnnotateDbContext dbContext) {
        this.dbContext = dbContext;
    }

    [HttpGet(Name = "GetAll")]
    public async Task<IEnumerable<Annotation>> GetAll() {
        return dbContext.Annotations;
    }
}