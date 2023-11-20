using Api.Data;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
  private readonly DataContext _dbContext;

  public ProductController(DataContext dbContext)
  {
    _dbContext = dbContext;
  }

  // GET: api/Product
  [HttpGet(Name = "GetAllProducts")]
  public async Task<IEnumerable<Product>> GetProducts()
  {
    return await _dbContext.Products.ToListAsync();
  }

  // GET: api/Product/id
  [HttpGet("{id}", Name = "GetProduct")]
  public async Task<ActionResult<Product>> GetById(int id)
  {
    var product = await _dbContext.Products.FindAsync(id);

    if (product == null)
    {
      return NotFound();
    }

    return product;
  }

  // POST api/product
  [HttpPost]
  public async Task<ActionResult<Product>> PostUser(Product product)
  {
    _dbContext.Products.Add(product);
    await _dbContext.SaveChangesAsync();

    return CreatedAtAction(nameof(GetProducts), new { id = product.ProductId }, product);
  }
}
