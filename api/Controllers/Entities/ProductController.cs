using api.Services;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using api.Utilities;
using api.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _service;

        public ProductsController(ProductService service)
    {
        _service = service;
    }

    [HttpGet("list", Name = "GetProducts")]
    public async Task<IEnumerable<Product>> Get()
    {
        return await _service.GetAll();
    }

    [HttpGet("list/id", Name = "GetProduct")]
    public async Task<ActionResult<Product>> GetById(int id)
    {
        var product = await _service.GetByID(id);

        if (product == null)
        {
            return ErrorUtilities.FieldNotFound("Product", id);
        }
        return product;
    }

    [Authorize(Policy = "SuperAdministrator")]
    [HttpPost("save", Name = "AddProduct")]
    public async Task<IActionResult> Create(ProductDTO productDTO)
    {
        var newProduct = await _service.Create(productDTO);
        if (newProduct.Name.Equals("error_409_validations")) {
           return ErrorUtilities.UniqueName("Product");
        }

        return CreatedAtAction(nameof(GetById), new { id = newProduct.ProductID }, productDTO);
    }

    [Authorize(Policy = "SuperAdministrator")]
    [HttpPut("edit", Name = "EditProduct")]
    public async Task<IActionResult> Update(int id, ProductDTO productDTO)
    {
      if ( id <= 0 )
      {
          return ErrorUtilities.IdPositive(id);
      }

      var productToUpdate = await _service.GetByID(id);

      if (productToUpdate is not null)
      {
        await _service.Update(id, productDTO);
        return NoContent();
      }
      else
      {
        return ErrorUtilities.FieldNotFound("Product", id);
      }
    }
  }
}
