using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Services
{
    public class ProviderService
    {
        private readonly DataContext _context;

        public ProviderService(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Provider>> GetAll()
    {
      return await _context.Providers.ToListAsync();
    }

    public async Task<Provider?> GetByID(int id)
    {
      return await _context.Providers.FindAsync(id);
    }

    public async Task<Provider> Create(Provider newProvider)
    {
      _context.Providers.Add(newProvider);
      await _context.SaveChangesAsync();

      return newProvider;
    }

    public async Task Update(int id, Provider provider)
    {
      var existingProvider = await GetByID(id);

      if (existingProvider is not null)
      {
      existingProvider.Name = provider.Name;
      existingProvider.Nationality = provider.Nationality;

      await _context.SaveChangesAsync();
     }
    }

    public async Task Delete(int id)
    {
      var providerToDelete = await GetByID(id);

      if(providerToDelete is not null)
      {
        _context.Providers.Remove(providerToDelete);
        await _context.SaveChangesAsync();
      }
    }
    }
}
