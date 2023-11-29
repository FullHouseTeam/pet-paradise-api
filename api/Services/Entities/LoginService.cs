using api.Data;
using api.DTOs.Entities;
using api.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace api.Services.Entities
{
    public class LoginService
    {
        private readonly DataContext _context;
        public LoginService(DataContext context) 
        {
            _context = context;
            InitializeAdminAsync().Wait();
        }

        public async Task<Administrator?> GetAdmin(AdministratorDTO admin)
        {
            return await _context.Administrators.
                      SingleOrDefaultAsync(x => x.Email == admin.Email && x.Password == admin.Password);
        }

        public async Task InitializeAdminAsync()
        {
            var existingAdmins = await _context.Administrators.ToListAsync();
            _context.Administrators.RemoveRange(existingAdmins);
            await _context.SaveChangesAsync();

            var superAdministrator = new Administrator
            {
            Name = "admin",
            Email = "superadmin@admin.com",
            AdminType = "SuperAdministrator",
            Password = "admin",
            RegisterDate = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ"),
            Nit = new Random().Next(100000000, 999999999),
            PhoneNumber = new Random().Next(100000000, 999999999)
            };

            var viewerAdministrator = new Administrator
            {
            Name = "admin",
            Email = "vieweradmin@admin.com",
            AdminType = "ViewerAdministrator",
            Password = "admin",
            RegisterDate = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ"),
            Nit = new Random().Next(100000000, 999999999),
            PhoneNumber = new Random().Next(100000000, 999999999)
            };
            _context.Administrators.Add(superAdministrator);
            _context.Administrators.Add(viewerAdministrator);
            await _context.SaveChangesAsync();
        }
    }
}