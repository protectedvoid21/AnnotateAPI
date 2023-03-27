using AnnotateAPI.Dtos;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnnotateAPI.Controllers;

[ApiController]
[Route("annotation/")]
public class AnnotationController : ControllerBase {
    private AnnotateDbContext dbContext;

    public AnnotationController(AnnotateDbContext dbContext) {
        this.dbContext = dbContext;
    }

    [HttpGet]
    public async Task<IActionResult> Get(int pictureId) {
        IEnumerable<Annotation> annotations = dbContext.Annotations.Where(a => a.PictureId == pictureId)
            .Include(a => a.Coordinates);

        if (!annotations.Any()) {
            return NotFound();
        }

        return Ok(annotations);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] AnnotationDto annotationDto) {
        if (!ModelState.IsValid) {
            return BadRequest(ModelState);
        }

        Annotation annotation = new() {
            AuthorId = annotationDto.AuthorId,
            PictureId = annotationDto.PictureId,
            Description = annotationDto.Description,
        };

        annotation.Coordinates = annotationDto.Coordinates.Select(c => new Coordinate {
            Annotation = annotation,
            X = c.Item1,
            Y = c.Item2,
        }).ToList();

        await dbContext.AddAsync(annotation);
        await dbContext.SaveChangesAsync();

        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] AnnotationEditDto annotationDto) {
        if (!ModelState.IsValid) {
            return BadRequest(ModelState);
        }

        Annotation annotation = await dbContext.Annotations.FindAsync(annotationDto.Id);

        if(annotation == null) {
            return NotFound();
        }

        annotation.Description = annotationDto.Description;
        dbContext.RemoveRange(annotation.Coordinates);

        annotation.Coordinates = annotationDto.Coordinates.Select(c => new Coordinate { AnnotationId = annotation.Id, X = c.Item1, Y = c.Item2 }).ToList();

        dbContext.Update(annotation);
        await dbContext.SaveChangesAsync();

        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id) {
        Annotation annotation = await dbContext.Annotations.FindAsync(id);

        if(annotation == null) {
            return NotFound();
        }

        dbContext.Remove(annotation);
        await dbContext.SaveChangesAsync();

        return Ok();
    }
}