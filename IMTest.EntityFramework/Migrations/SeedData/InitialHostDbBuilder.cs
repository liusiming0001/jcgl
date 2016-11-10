using IMTest.EntityFramework;
using EntityFramework.DynamicFilters;

namespace IMTest.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly IMTestDbContext _context;

        public InitialHostDbBuilder(IMTestDbContext context)
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
