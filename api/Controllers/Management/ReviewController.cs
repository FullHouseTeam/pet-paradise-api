using api.DTOs;
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
          return ErrorUtilities.FieldNotFound("Review", id);
        }
        return review;
    }

    [HttpPost("save", Name = "AddReview")]
    public async Task<IActionResult> Create(ReviewDTO reviewDTO)
    {
        var newReview = await _service.Create(reviewDTO);

        return CreatedAtAction(nameof(GetById), new { id = newReview.ReviewID }, reviewDTO);
    }

    [HttpPut("edit", Name = "EditReview")]
    public async Task<IActionResult> Update(int id, ReviewDTO reviewDTO)
    {
      if ( id <= 0 )
      {
          return ErrorUtilities.IdPositive(id);
      }

      var reviewToUpdate = await _service.GetByID(id);

      if (reviewToUpdate is not null)
      {
        await _service.Update(id, reviewDTO);
        return NoContent();
      }
      else
      {
        return ErrorUtilities.FieldNotFound("Review", id);
      }
    }
  }
}