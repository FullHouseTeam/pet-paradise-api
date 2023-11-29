using api.DTOs;
using api.Models;
using api.Services;
using api.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PurchaseController : ControllerBase
    {
        private readonly PurchaseService _service;

        public PurchaseController(PurchaseService service)
    {
        _service = service;
    }

    [HttpGet("list", Name = "GetPurchases")]
    public async Task<IEnumerable<Purchase>> Get()
    {
        return await _service.GetAll();
    }

    [HttpGet("list/id", Name = "GetPurchase")]
    public async Task<ActionResult<Purchase>> GetById(int id)
    {
        var purchase = await _service.GetByID(id);

        if ( id <= 0 )
        {
          return ErrorUtilities.IdPositive(id);
        }

        if (purchase == null)
        {
          return ErrorUtilities.FieldNotFound("Purchase", id);
        }
        return purchase;
    }

    [Authorize(Policy = "SuperAdministrator")]
    [HttpPost("save", Name = "AddPurchase")]
    public async Task<IActionResult> Create(PurchaseDTO purchaseDTO)
    {
        var newPurchase = await _service.Create(purchaseDTO);

        return CreatedAtAction(nameof(GetById), new { id = newPurchase.PurchaseID }, purchaseDTO);
    }

    [Authorize(Policy = "SuperAdministrator")]
    [HttpPut("edit", Name = "EditPurchase")]
    public async Task<IActionResult> Update(int id, PurchaseDTO purchaseDTO)
    {
      if ( id <= 0 )
      {
          return ErrorUtilities.IdPositive(id);
      }

      var purchaseToUpdate = await _service.GetByID(id);

      if (purchaseToUpdate is not null)
      {
        await _service.Update(id, purchaseDTO);
        return NoContent();
      }
      else
      {
        return ErrorUtilities.FieldNotFound("Purchase", id);
      }
    }
  }
}
