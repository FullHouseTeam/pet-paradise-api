
using api.Data;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly DataContext _context;

        public ProductsController(ILogger<ProductsController> logger, DataContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet(Name = "GetProductos")]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        return await _context.Products.ToListAsync();
    }

    [HttpGet("{id}", Name = "GetProducto")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        var product = await _context.Products.FindAsync(id);

        if (product == null)
        {
            return NotFound(new {message = $"The product with ID = {id} doesn't exist."});
        }

        return product;
    }

    [HttpPost]
    public async Task<ActionResult<Product>> Post(Product producto)
    {
        _context.Products.Add(producto);
        await _context.SaveChangesAsync();

        return new CreatedAtRouteResult("GetProducto", new { id = producto.ProductID }, producto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, Product producto)
    {
        if (id != producto.ProductID)
        {
            return BadRequest(new {message = $"The ID({id}) URL doesn't match ID({producto.ProductID}) of the request body."});
        }

        _context.Entry(producto).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Product>> Delete(int id)
    {
        var producto = await _context.Products.FindAsync(id);

        if (producto == null)
        {
            return NotFound();
        }

        _context.Remove(producto);
        await _context.SaveChangesAsync();

        return producto;
    }
    }
}
