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

    [HttpGet(Name = "GetAll")]
    public async Task<IEnumerable<Annotation>> GetAll(int pictureId) {
        return await annotationService.GetAllForPicture(pictureId);
    }

    [HttpPost(Name = "Add")]
    public async Task Add([FromBody] AnnotationDto annotationDto) {
        await annotationService.AddAsync(annotationDto.AuthorId, annotationDto.Description, annotationDto.Coordinates);
    }
}