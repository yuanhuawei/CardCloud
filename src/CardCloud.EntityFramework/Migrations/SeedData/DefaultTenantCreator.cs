using System.Linq;
using CardCloud.EntityFramework;
using CardCloud.MultiTenancy;

namespace CardCloud.Migrations.SeedData
{
    public class DefaultTenantCreator
    {
        private readonly CardCloudDbContext _context;

        public DefaultTenantCreator(CardCloudDbContext context)
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

            var defaultTenant = _context.Tenants.FirstOrDefault(t => t.TenancyName == Tenant.DefaultTenantName);
            if (defaultTenant == null)
            {
                _context.Tenants.Add(new Tenant {TenancyName = Tenant.DefaultTenantName, Name = Tenant.DefaultTenantName});
                _context.SaveChanges();
            }
        }
    }
}
