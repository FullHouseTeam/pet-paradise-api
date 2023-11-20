using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Services
{
    public class PurchaseService
    {
        private readonly DataContext _context;

        public PurchaseService(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Purchase>> GetAll()
    {
      return await _context.Purchases.ToListAsync();
    }

    public async Task<Purchase?> GetByID(int id)
    {
      return await _context.Purchases.FindAsync(id);
    }

    public async Task<Purchase> Create(Purchase newPurchase)
    {
      _context.Purchases.Add(newPurchase);
      await _context.SaveChangesAsync();

      return newPurchase;
    }

    public async Task Update(int id, Purchase purchase)
    {
      var existingPurchase = await GetByID(id);

      if (existingPurchase is not null)
      {
      existingPurchase.TotalPrice = purchase.TotalPrice;
      existingPurchase.ObtainedTaxes = purchase.ObtainedTaxes;
      existingPurchase.ApplicationTax = purchase.ApplicationTax;
      existingPurchase.DeliveryTime = purchase.DeliveryTime;
      existingPurchase.ProductID = purchase.ProductID;
      existingPurchase.UserID = purchase.UserID;

      await _context.SaveChangesAsync();
     }
    }

    public async Task Delete(int id)
    {
      var purchaseToDelete = await GetByID(id);

      if(purchaseToDelete is not null)
      {
        _context.Purchases.Remove(purchaseToDelete);
        await _context.SaveChangesAsync();
      }
    }
    }
}