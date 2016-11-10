using System.Linq;
using IMTest.EntityFramework;
using IMTest.MultiTenancy;

namespace IMTest.Migrations.SeedData
{
    public class DefaultTenantCreator
    {
        private readonly IMTestDbContext _context;

        public DefaultTenantCreator(IMTestDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateUserAndRoles();
        }

        private void CreateUserAndRoles()
        {
            //Default tenant

            var defaultTenant = _context.Tenants.FirstOrDefault(t => t.TenancyName == "Default");
            if (defaultTenant == null)
            {
                _context.Tenants.Add(new Tenant {TenancyName = "Default", Name = "Default"});
                _context.SaveChanges();
            }
        }
    }
}