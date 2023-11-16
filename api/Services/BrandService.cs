
using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Services
{
    public class BrandService
    {
        private readonly DataContext _context;

        public BrandService(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Brand>> GetAll()
    {
      return await _context.Brands.ToListAsync();
    }

    public async Task<Brand?> GetByID(int id)
    {
      return await _context.Brands.FindAsync(id);
    }

    public async Task<Brand> Create(Brand newBrand)
    {
      _context.Brands.Add(newBrand);
      await _context.SaveChangesAsync();

      return newBrand;
    }

    public async Task Update(int id, Brand brand)
    {
      var existingBrand = await GetByID(id);

      if (existingBrand is not null)
      {
      existingBrand.Name = brand.Name;
      existingBrand.Logo = brand.Logo;

      await _context.SaveChangesAsync();
     }
    }

    public async Task Delete(int id)
    {
      var brandToDelete = await GetByID(id);

      if(brandToDelete is not null)
      {
        _context.Brands.Remove(brandToDelete);
        await _context.SaveChangesAsync();
      }
    }
    }
}
