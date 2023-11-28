using api.DTOs;
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
          return ErrorUtilities.FieldNotFound("Provider", id);
        }
        return product;
    }

    [HttpPost("save", Name = "AddProvider")]
    public async Task<IActionResult> Create(ProviderDTO providerDTO)
    {
        var newProvider = await _service.Create(providerDTO);
        if (newProvider.Name.Equals("error_409_validations")) {
           return ErrorUtilities.UniqueName("Provider");
        }

        return CreatedAtAction(nameof(GetById), new { id = newProvider.ProviderID }, providerDTO);
    }

    [HttpPut("edit", Name = "EditProvider")]
    public async Task<IActionResult> Update(int id, ProviderDTO providerDTO)
    {
      if ( id <= 0 )
      {
          return ErrorUtilities.IdPositive(id);
      }

      var providerToUpdate = await _service.GetByID(id);

      if (providerToUpdate is not null)
      {
        await _service.Update(id, providerDTO);
        return NoContent();
      }
      else
      {
        return ErrorUtilities.FieldNotFound("Provider", id);
      }
    }
  }
}