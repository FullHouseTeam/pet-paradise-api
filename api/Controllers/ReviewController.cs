using api.Models;
using api.Services;
using api.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly ReviewService _service;

        public ReviewController(ReviewService service)
    {
        _service = service;
    }

    [HttpGet("list", Name = "GetReviews")]
    public async Task<IEnumerable<Review>> Get()
    {
        return await _service.GetAll();
    }

    [HttpGet("list/id", Name = "GetReview")]
    public async Task<ActionResult<Review>> GetById(int id)
    {
        var review = await _service.GetByID(id);

        if ( id <= 0 )
        {
          return ErrorUtilities.IdPositive(id);
        }

        if (review == null)
        {
          return ErrorUtilities.BrandNotFound(id);
        }
        return review;
    }

    [HttpPost("save", Name = "AddReview")]
    public async Task<IActionResult> Create(Review review)
    {
        var newReview = await _service.Create(review);

        return CreatedAtAction(nameof(GetById), new { id = newReview.ReviewID }, review);
    }

    [HttpPut("edit", Name = "EditReview")]
    public async Task<IActionResult> Update(int id, Review review)
    {
      if ( id <= 0 )
      {
          return ErrorUtilities.IdPositive(id);
      }

      if (id != review.ReviewID)
      {
        return BadRequest(new { message = $"The ID({id}) URL doesn't match ID({review.ReviewID}) of the request body."});
      }

      var reviewToUpdate = await _service.GetByID(id);

      if (reviewToUpdate is not null)
      {
        await _service.Update(id, review);
        return NoContent();
      }
      else
      {
        return ErrorUtilities.BrandNotFound(id);
      }
    }
  }
}