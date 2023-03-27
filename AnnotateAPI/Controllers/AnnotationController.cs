using AnnotateAPI.Dtos;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.Annotations;

namespace AnnotateAPI.Controllers;

[ApiController]
[Route("annotation/")]
public class AnnotationController : ControllerBase {
    private AnnotateDbContext dbContext;

    public AnnotationController(AnnotateDbContext dbContext) {
        this.dbContext = dbContext;
    }

    [HttpGet]
    public async Task<IEnumerable<Annotation>> Get(int pictureId) {
        return dbContext.Annotations.Where(a => a.PictureId == pictureId)
            .Include(a => a.Coordinates);
    }

    [HttpPost]
    public async Task Add([FromBody] AnnotationDto annotationDto) {
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
    }

    [HttpPut]
    public async Task Update([FromBody] AnnotationEditDto annotationDto) {
        Annotation annotation = await dbContext.Annotations.FindAsync(id);

        if(annotation == null) {
            return;
        }

        annotation.Description = annotationDto.Description;
        dbContext.RemoveRange(annotation.Coordinates);

        annotation.Coordinates = annotationDto.Coordinates.Select(c => new Coordinate { AnnotationId = id, X = c.Item1, Y = c.Item2 }).ToList();

        dbContext.Update(annotation);
        await dbContext.SaveChangesAsync();
    }

    [HttpDelete]
    public async Task Delete(int id) {
        Annotation annotation = await dbContext.Annotations.FindAsync(id);

        if(annotation == null) {
            return;
        }

        dbContext.Remove(annotation);
        await dbContext.SaveChangesAsync();
    }
}