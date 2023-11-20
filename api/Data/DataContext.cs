using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        {

        }
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Brand> Brands => Set<Brand>();
        public DbSet<Provider> Providers => Set<Provider>();
    }
}
