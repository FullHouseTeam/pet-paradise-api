using api.Models;
using api.Services;
using api.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProviderController : ControllerBase
    {
        private readonly ProviderService _service;

        public ProviderController(ProviderService service)
    {
        _service = service;
    }

    [HttpGet(Name = "GetProviders")]
    public async Task<IEnumerable<Provider>> Get()
    {
        return await _service.GetAll();
    }

    [HttpGet("{id}", Name = "GetProvider")]
    public async Task<ActionResult<Provider>> GetById(int id)
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

    [HttpPost(Name = "AddProvider")]
    public async Task<IActionResult> Create(Provider provider)
    {
        var newProvider = await _service.Create(provider);

        return CreatedAtAction(nameof(GetById), new { id = newProvider.ProviderID }, provider);
    }

    [HttpPut("{id}", Name = "EditProvider")]
    public async Task<IActionResult> Update(int id, Provider provider)
    {
      if ( id <= 0 )
      {
          return ErrorUtilities.IdPositive(id);
      }

      if (id != provider.ProviderID)
      {
        return BadRequest(new { message = $"The ID({id}) URL doesn't match ID({provider.ProviderID}) of the request body."});
      }

      var providerToUpdate = await _service.GetByID(id);

      if (providerToUpdate is not null)
      {
        await _service.Update(id, provider);
        return NoContent();
      }
      else
      {
        return ErrorUtilities.BrandNotFound(id);
      }
    }

    [HttpDelete("{id}", Name = "DeleteProvider")]
     public async Task<IActionResult> Delete(int id)
    {
      if ( id <= 0 )
      {
          return ErrorUtilities.IdPositive(id);
      }

      var providerToDelete = await _service.GetByID(id);

      if (providerToDelete is not null)
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