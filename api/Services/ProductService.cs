using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Services
{
    public class ProductService
    {
        private readonly DataContext _context;

        public ProductService(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAll()
    {
      return await _context.Products.ToListAsync();
    }

    public async Task<Product?> GetByID(int id)
    {
      return await _context.Products.FindAsync(id);
    }

    public async Task<Product> Create(Product newProduct)
    {
      _context.Products.Add(newProduct);
      await _context.SaveChangesAsync();

      return newProduct;
    }

    public async Task Update(int id, Product product)
    {
      var existingProduct = await GetByID(id);

      if (existingProduct is not null)
      {
      existingProduct.Name = product.Name;
      existingProduct.Price = product.Price;
      existingProduct.Quantity = product.Quantity;
      existingProduct.Discount = product.Quantity;
      existingProduct.AnimalCategory = product.AnimalCategory;
      existingProduct.Image = product.Image;
      existingProduct.Description = product.Description;
      existingProduct.BrandID = product.BrandID;
      existingProduct.ProviderID = product.ProviderID;
      existingProduct.HasTax = product.HasTax;

      await _context.SaveChangesAsync();
     }
    }

    public async Task Delete(int id)
    {
      var productToDelete = await GetByID(id);

      if(productToDelete is not null)
      {
        _context.Products.Remove(productToDelete);
        await _context.SaveChangesAsync();
      }
    }
    }
}