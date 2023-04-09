using AnnotateAPI.Dtos;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AnnotateAPI.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class DatasetController : ControllerBase {
    private readonly AnnotateDbContext dbContext;
    private readonly UserManager<AppUser> userManager;

    public DatasetController(AnnotateDbContext dbContext, UserManager<AppUser> userManager) {
        this.dbContext = dbContext;
        this.userManager = userManager;
    }

    [HttpGet]
    public async Task<IActionResult> Get() {
        var currentUser = await userManager.GetUserAsync(User);
        if (currentUser == null) {
            return BadRequest();
        }

        IEnumerable<PictureDataset> datasets = dbContext.PictureDatsetUsers
            .Where(pd => pd.AnnotatorId == currentUser.Id)
            .Select(pd => pd.PictureDataset);

        return Ok(datasets);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] PictureDatasetAddDto datasetDto) {
        if (!ModelState.IsValid) {
            return BadRequest(datasetDto);
        }
        
        PictureDataset dataset = new() {
            CreateDate = DateTime.Now,
            Annotators = dbContext.Users.
            PictureIds = datasetDto.PictureIds
        };

        await dbContext.AddAsync(dataset);
        await dbContext.SaveChangesAsync();

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id) {
        PictureDataset dataset = await dbContext.PictureDatasets.FindAsync(id);

        if (dataset == null) {
            return NotFound();
        }

        dbContext.Remove(dataset);
        await dbContext.SaveChangesAsync();

        return Ok();
    }
}