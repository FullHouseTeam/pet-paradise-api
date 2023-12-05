using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api_test.UnitTest.Data
{
    public class DataContextTest : IDisposable
    {
        private readonly DbContextOptions<DataContext> _options;
        private readonly DataContext _context;

        public DataContextTest()
        {
            _options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new DataContext(_options);

            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            _context.Brands.Add(new Brand { BrandID = 1, Name = "Brand1" });
            _context.Brands.Add(new Brand { BrandID = 2, Name = "Brand2" });
            _context.SaveChanges();
        }

        [Fact]
        public void Brands_ShouldContainTestData()
        {
            var brands = _context.Brands.ToList();
            Assert.Equal(2, brands.Count);
        }

        [Fact]
        public void AddBrand_ShouldIncreaseBrandCount()
        {
            var brandCountBefore = _context.Brands.Count();
            var newBrand = new Brand { BrandID = 3, Name = "Brand3" };

            _context.Brands.Add(newBrand);
            _context.SaveChanges();

            var brandCountAfter = _context.Brands.Count();
            Assert.Equal(brandCountBefore + 1, brandCountAfter);
        }

               [Fact]
        public void UpdateBrand_ShouldModifyExistingBrand()
        {
            var brandToUpdate = _context.Brands.FirstOrDefault(b => b.BrandID == 1);

            if (brandToUpdate != null)
            {
                brandToUpdate.Name = "UpdatedBrand";
                _context.SaveChanges();

                var updatedBrand = _context.Brands.FirstOrDefault(b => b.BrandID == 1);
                Assert.Equal("UpdatedBrand", updatedBrand?.Name);
            }
        }

        [Fact]
        public void DeleteBrand_ShouldRemoveBrandFromDatabase()
        {
            var brandCountBefore = _context.Brands.Count();
            var brandToDelete = _context.Brands.FirstOrDefault(b => b.BrandID == 2);

            if (brandToDelete != null)
            {
                _context.Brands.Remove(brandToDelete);
                _context.SaveChanges();

                var brandCountAfter = _context.Brands.Count();
                Assert.Equal(brandCountBefore - 1, brandCountAfter);
            }
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}
