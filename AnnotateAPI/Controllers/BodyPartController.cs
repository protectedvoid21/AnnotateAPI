using AnnotateAPI.Dtos;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnnotateAPI.Controllers; 

[Route("api/[controller]")]
[Authorize]
[ApiController]
public class BodyPartController : ControllerBase {
    private readonly AnnotateDbContext dbContext;

    public BodyPartController(AnnotateDbContext dbContext) {
        this.dbContext = dbContext;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() {
        return Ok(dbContext.BodyPartTypes);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] BodyPartDto bodyPartDto) {
        if (!ModelState.IsValid) {
            return BadRequest(ModelState);
        }

        BodyPartType bodyPart = new BodyPartType { Name = bodyPartDto.Name };

        await dbContext.AddAsync(bodyPart);
        await dbContext.SaveChangesAsync();

        return Ok(bodyPart);
    }

    [HttpPut]
    public async Task<IActionResult> Update(int id, string name) {
        BodyPartType bodyPart = await dbContext.BodyPartTypes.FindAsync(id);

        if (bodyPart == null) {
            return NotFound();
        }

        bodyPart.Name = name;

        dbContext.Update(bodyPart);
        await dbContext.SaveChangesAsync();

        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id) {
        BodyPartType bodyPart = await dbContext.BodyPartTypes.FindAsync(id);

        if (bodyPart == null) {
            return NotFound();
        }

        return Ok(bodyPart);
    }
}