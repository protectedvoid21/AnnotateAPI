using AnnotateAPI.Dtos;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AnnotateAPI.Controllers;

[ApiController]
[Authorize]
[Route("api/review")]
public class ReviewController : ControllerBase {
    private readonly AnnotateDbContext dbContext;
    private readonly UserManager<AppUser> userManager;

    public ReviewController(AnnotateDbContext dbContext, UserManager<AppUser> userManager) {
        this.dbContext = dbContext;
        this.userManager = userManager;
    }

    [HttpGet]
    public async Task<IActionResult> Get(int annotationId) {
        var review = await dbContext.AnnotationReviews.FindAsync(annotationId);

        if (review == null) {
            return NotFound();
        }

        return Ok(review);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] AnnotationReviewAddDto reviewDto) {
        if (!ModelState.IsValid) {
            return BadRequest();
        }

        AnnotationReview annotationReview = new() {
            AnnotationId = reviewDto.AnnotationId,
            ExpertId = reviewDto.ExpertId,
            Description = reviewDto.Description,
        };

        await dbContext.AddAsync(annotationReview);
        await dbContext.SaveChangesAsync();

        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] AnnotationReviewUpdateDto reviewDto) {
        if (!ModelState.IsValid) {
            return BadRequest();
        }

        var review = await dbContext.AnnotationReviews.FindAsync(reviewDto.Id);

        if (review == null) {
            return BadRequest();
        }

        if (review.Id != reviewDto.Id) {
            return BadRequest();
        }

        review.Description = reviewDto.Description;
        dbContext.Update(review);
        await dbContext.SaveChangesAsync();

        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int reviewId) {
        var review = await dbContext.AnnotationReviews.FindAsync(reviewId);
        if (review == null) {
            return BadRequest();
        }

        var user = await userManager.GetUserAsync(User);

        if (!user.Id.Equals(review.ExpertId)) {
            return BadRequest();
        }

        dbContext.Remove(review);
        await dbContext.SaveChangesAsync();

        return Ok();
    }
}