using api.Models;
using api.Services;
using api.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PurchaseController : ControllerBase
    {
        private readonly PurchaseService _service;

        public PurchaseController(PurchaseService service)
    {
        _service = service;
    }

    [HttpGet(Name = "GetPurchases")]
    public async Task<IEnumerable<Purchase>> Get()
    {
        return await _service.GetAll();
    }

    [HttpGet("{id}", Name = "GetPurchase")]
    public async Task<ActionResult<Purchase>> GetById(int id)
    {
        var purchase = await _service.GetByID(id);

        if ( id <= 0 )
        {
          return ErrorUtilities.IdPositive(id);
        }

        if (purchase == null)
        {
          return ErrorUtilities.BrandNotFound(id);
        }
        return purchase;
    }

    [HttpPost(Name = "AddPurchase")]
    public async Task<IActionResult> Create(Purchase purchase)
    {
        var newPurchase = await _service.Create(purchase);

        return CreatedAtAction(nameof(GetById), new { id = newPurchase.PurchaseID }, purchase);
    }

    [HttpPut("{id}", Name = "EditPurchase")]
    public async Task<IActionResult> Update(int id, Purchase purchase)
    {
      if ( id <= 0 )
      {
          return ErrorUtilities.IdPositive(id);
      }

      if (id != purchase.PurchaseID)
      {
        return BadRequest(new { message = $"The ID({id}) URL doesn't match ID({purchase.PurchaseID}) of the request body."});
      }

      var purchaseToUpdate = await _service.GetByID(id);

      if (purchaseToUpdate is not null)
      {
        await _service.Update(id, purchase);
        return NoContent();
      }
      else
      {
        return ErrorUtilities.BrandNotFound(id);
      }
    }

    [HttpDelete("{id}", Name = "DeletePurchase")]
     public async Task<IActionResult> Delete(int id)
    {
      if ( id <= 0 )
      {
          return ErrorUtilities.IdPositive(id);
      }

      var purchaseToDelete = await _service.GetByID(id);

      if (purchaseToDelete is not null)
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
