using AnnotateAPI.Dtos;
using Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace AnnotateAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PictureController : ControllerBase {
    private readonly AnnotateDbContext dbContext;

    public PictureController(AnnotateDbContext dbContext) {
        this.dbContext = dbContext;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetById(int id) {
        Picture picture = await dbContext.Pictures.FindAsync(id);

        if (picture == null) {
            return NotFound();
        }

        return Ok(picture);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] PictureDto pictureDto) {
        if(!ModelState.IsValid) {
            return BadRequest(ModelState);
        }

        Picture picture = new() {
            Name = pictureDto.Name,
            BodyPartTypeId = pictureDto.BodyPartTypeId,
            Description = pictureDto.Description,
            CreatedDate = DateTime.Now
        };

        await dbContext.AddAsync(picture);
        await dbContext.SaveChangesAsync();

        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] PictureEditDto pictureDto) {
        if (!ModelState.IsValid) {
            return BadRequest();
        }

        Picture picture = await dbContext.Pictures.FindAsync(pictureDto.Id);

        if (picture == null) {
            return BadRequest();
        }

        picture.Name = pictureDto.Name;
        picture.BodyPartTypeId = pictureDto.BodyPartTypeId;
        picture.Description = pictureDto.Description;

        dbContext.Update(picture);
        await dbContext.SaveChangesAsync();

        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id) {
        Picture picture = await dbContext.Pictures.FindAsync(id);

        if (picture == null) {
            return BadRequest();
        }

        dbContext.Remove(picture);
        await dbContext.SaveChangesAsync();

        return Ok();
    }
}