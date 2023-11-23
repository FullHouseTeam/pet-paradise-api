using api.Models;
using api.Services;
using api.Utilities;
using AutoMapper;
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

    [HttpGet("list", Name = "GetProviders")]
    public async Task<IEnumerable<Provider>> Get()
    {
        return await _service.GetAll();
    }

    [HttpGet("list/id", Name = "GetProvider")]
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

    [HttpPost("save", Name = "AddProvider")]
    public async Task<IActionResult> Create(Provider provider)
    {
        var newProvider = await _service.Create(provider);

        return CreatedAtAction(nameof(GetById), new { id = newProvider.ProviderID }, provider);
    }

    [HttpPut("edit", Name = "EditProvider")]
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
  }
}