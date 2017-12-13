using CardCloud.EntityFramework;
using EntityFramework.DynamicFilters;

namespace CardCloud.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly CardCloudDbContext _context;

        public InitialHostDbBuilder(CardCloudDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
