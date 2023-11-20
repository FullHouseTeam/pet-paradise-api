using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Services
{
    public class CustomerService
    {
        private readonly DataContext _context;

        public CustomerService(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Customer>> GetAll()
    {
      return await _context.Customers.ToListAsync();
    }

    public async Task<Customer?> GetByID(int id)
    {
      return await _context.Customers.FindAsync(id);
    }

    public async Task<Customer> Create(Customer newCustomer)
    {
      _context.Customers.Add(newCustomer);
      await _context.SaveChangesAsync();

      return newCustomer;
    }

    public async Task Update(int id, Customer customer)
    {
      var existingCustomer = await GetByID(id);

      if (existingCustomer is not null)
      {
      existingCustomer.Email = customer.Name;
      existingCustomer.Name = customer.Name;
      existingCustomer.Password = customer.Password;
      existingCustomer.RegionID = customer.RegionID;
      existingCustomer.Nit = customer.Nit;

      await _context.SaveChangesAsync();
     }
    }

    public async Task Delete(int id)
    {
      var customerToDelete = await GetByID(id);

      if(customerToDelete is not null)
      {
        _context.Customers.Remove(customerToDelete);
        await _context.SaveChangesAsync();
      }
    }
    }
}