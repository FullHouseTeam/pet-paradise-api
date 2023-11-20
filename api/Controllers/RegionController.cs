using api.Models;
using api.Services;
using api.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegionController : ControllerBase
    {
        private readonly RegionService _service;

        public RegionController(RegionService service)
    {
        _service = service;
    }

    [HttpGet(Name = "GetRegions")]
    public async Task<IEnumerable<Region>> Get()
    {
        return await _service.GetAll();
    }

    [HttpGet("{id}", Name = "GetRegion")]
    public async Task<ActionResult<Region>> GetById(int id)
    {
        var product = await _service.GetByID(id);

        if ( id <= 0 )
        {
          return ErrorUtilities.IdPositive(id);
        }

        if (product == null)
        {
          return ErrorUtilities.BrandNotFound(id);
        }
        return product;
    }

    [HttpPost(Name = "AddRegion")]
    public async Task<IActionResult> Create(Region region)
    {
        var newRegion = await _service.Create(region);

        return CreatedAtAction(nameof(GetById), new { id = newRegion.RegionID }, region);
    }

    [HttpPut("{id}", Name = "EditRegion")]
    public async Task<IActionResult> Update(int id, Region region)
    {
      if ( id <= 0 )
      {
          return ErrorUtilities.IdPositive(id);
      }

      if (id != region.RegionID)
      {
        return BadRequest(new { message = $"The ID({id}) URL doesn't match ID({region.RegionID}) of the request body."});
      }

      var regionToUpdate = await _service.GetByID(id);

      if (regionToUpdate is not null)
      {
        await _service.Update(id, region);
        return NoContent();
      }
      else
      {
        return ErrorUtilities.BrandNotFound(id);
      }
    }

    [HttpDelete("{id}", Name = "DeleteRegion")]
     public async Task<IActionResult> Delete(int id)
    {
      if ( id <= 0 )
      {
          return ErrorUtilities.IdPositive(id);
      }

      var religionToDelete = await _service.GetByID(id);

      if (religionToDelete is not null)
      {
        await _service.Delete(id);
        return Ok();
      }
      else
      {
        return ErrorUtilities.BrandNotFound(id);
      }
    }
    }
}