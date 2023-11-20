using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Services
{
    public class RegionService
    {
        private readonly DataContext _context;

        public RegionService(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Region>> GetAll()
    {
      return await _context.Regions.ToListAsync();
    }

    public async Task<Region?> GetByID(int id)
    {
      return await _context.Regions.FindAsync(id);
    }

    public async Task<Region> Create(Region newRegion)
    {
      _context.Regions.Add(newRegion);
      await _context.SaveChangesAsync();

      return newRegion;
    }

    public async Task Update(int id, Region region)
    {
      var existingRegion = await GetByID(id);

      if (existingRegion is not null)
      {
      existingRegion.MunicipalTax = region.MunicipalTax;
      existingRegion.StatalTax = region.StatalTax;

      await _context.SaveChangesAsync();
     }
    }

    public async Task Delete(int id)
    {
      var regionToDelete = await GetByID(id);

      if(regionToDelete is not null)
      {
        _context.Regions.Remove(regionToDelete);
        await _context.SaveChangesAsync();
      }
    }
    }
}
