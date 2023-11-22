using api.Models;
using api.Services;
using api.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BrandController : ControllerBase
    {
        private readonly BrandService _service;

        public BrandController(BrandService service)
    {
        _service = service;
    }

    [HttpGet(Name = "GetBrands")]
    public async Task<IEnumerable<Brand>> Get()
    {
        return await _service.GetAll();
    } 


    [HttpGet("{id}", Name = "GetBrand")]
    public async Task<ActionResult<Brand>> GetById(int id)
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

    [HttpPost(Name = "AddBrand")]
    public async Task<IActionResult> Create(Brand brand)
    {
        var newBrand = await _service.Create(brand);

        return CreatedAtAction(nameof(GetById), new { id = newBrand.BrandID }, brand);
    }

    [HttpPut("{id}", Name = "EditBrand")]
    public async Task<IActionResult> Update(int id, Brand brand)
    {
      if ( id <= 0 )
      {
          return ErrorUtilities.IdPositive(id);
      }

      if (id != brand.BrandID)
      {
        return BadRequest(new { message = $"The ID({id}) URL doesn't match ID({brand.BrandID}) of the request body."});
      }

      var brandToUpdate = await _service.GetByID(id);

      if (brandToUpdate is not null)
      {
        await _service.Update(id, brand);
        return NoContent();
      }
      else
      {
        return ErrorUtilities.BrandNotFound(id);
      }
    }

    [HttpDelete("{id}", Name = "DeleteBrand")]
     public async Task<IActionResult> Delete(int id)
    {
      if ( id <= 0 )
      {
          return ErrorUtilities.IdPositive(id);
      }

      var brandToDelete = await _service.GetByID(id);

      if (brandToDelete is not null)
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
