using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Pictures;

namespace AnnotateAPI.Controllers;

[ApiController]
[Route("/picture")]
public class PictureController : ControllerBase {
    private readonly AnnotateDbContext dbContext;

    public PictureController(AnnotateDbContext dbContext) {
        this.dbContext = dbContext;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetById(int id) {
        Annotation annotation = await dbContext.Annotations.FindAsync(id);

        if (annotation == null) {
            return NotFound();
        }

        return Ok(annotation);
    }
}