using AnnotateAPI.Dtos;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Annotations;

namespace AnnotateAPI.Controllers;

[ApiController]
[Route("annotation/")]
public class AnnotationController : ControllerBase {
    private IAnnotationService annotationService;

    public AnnotationController(IAnnotationService annotationService) {
        this.annotationService = annotationService;
    }

    [HttpGet]
    public async Task<IEnumerable<Annotation>> Get(int pictureId) {
        return await annotationService.GetAllForPicture(pictureId);
    }

    [HttpPost]
    public async Task Add([FromBody] AnnotationDto annotationDto) {
        await annotationService.AddAsync(annotationDto.AuthorId, annotationDto.PictureId, annotationDto.Description, annotationDto.Coordinates);
    }

    [HttpPut]
    public async Task Update([FromBody] AnnotationEditDto annotationDto) {
        await annotationService.UpdateAsync(annotationDto.Id, annotationDto.Description, annotationDto.Coordinates);
    }

    [HttpDelete]
    public async Task Delete(int id) {
        await annotationService.DeleteAsync(id);
    }
}