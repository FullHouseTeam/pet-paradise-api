
using api.Services;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using api.Utilities;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _service;

        public ProductsController(ProductService service)
    {
        _service = service;
    }

    [HttpGet(Name = "GetProductos")]
    public async Task<IEnumerable<Product>> Get()
    {
        return await _service.GetAll();
    }

    [HttpGet("{id}", Name = "GetProducto")]
    public async Task<ActionResult<Product>> GetById(int id)
    {
        var product = await _service.GetByID(id);

        if ( id <= 0 )
        {
          return ErrorUtilities.IdPositive(id);
        }

        if ( product == null )
        {
            return ErrorUtilities.ProductNotFound(id);
        }
        return product;
    }

    [HttpPost(Name = "AddProducto")]
    public async Task<IActionResult> Create(Product product)
    {
        var newProduct = await _service.Create(product);

        return CreatedAtAction(nameof(GetById), new { id = newProduct.ProductID }, product);
    }

    [HttpPut("{id}", Name = "EditProduct")]
    public async Task<IActionResult> Update(int id, Product product)
    {
      if ( id <= 0 )
      {
          return ErrorUtilities.IdPositive(id);
      }
      
      if (id != product.ProductID)
      {
        return BadRequest(new { message = $"The ID({id}) URL doesn't match ID({product.ProductID}) of the request body."});
      }

      var productToUpdate = await _service.GetByID(id);

      if (productToUpdate is not null)
      {
        await _service.Update(id, product);
        return NoContent();
      }
      else
      {
        return ErrorUtilities.ProductNotFound(id);
      }
    }

    [HttpDelete("{id}", Name = "DeleteProduct")]
     public async Task<IActionResult> Delete(int id)
    {
      if ( id <= 0 )
      {
          return ErrorUtilities.IdPositive(id);
      }

      var productToDelete = await _service.GetByID(id);

      if (productToDelete is not null)
      {
        await _service.Delete(id);
        return Ok();
      }
      else
      {
        return ErrorUtilities.ProductNotFound(id);
      }
    }
    }
}
