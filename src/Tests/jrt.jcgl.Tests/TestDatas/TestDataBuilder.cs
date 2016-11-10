using EntityFramework.DynamicFilters;
using jrt.jcgl.EntityFramework;

namespace jrt.jcgl.Tests.TestDatas
{
    public class TestDataBuilder
    {
        private readonly AbpZeroTemplateDbContext _context;

        public TestDataBuilder(AbpZeroTemplateDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new TestOrganizationUnitsBuilder(_context).Create();

            _context.SaveChanges();
        }
    }
}
