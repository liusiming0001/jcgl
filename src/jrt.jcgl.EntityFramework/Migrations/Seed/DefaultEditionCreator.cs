using System.Linq;
using Abp.Application.Editions;
using jrt.jcgl.Editions;
using jrt.jcgl.EntityFramework;

namespace jrt.jcgl.Migrations.Seed
{
    public class DefaultEditionCreator
    {
        private readonly AbpZeroTemplateDbContext _context;

        public DefaultEditionCreator(AbpZeroTemplateDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateEditions();
        }

        private void CreateEditions()
        {
            var defaultEdition = _context.Editions.FirstOrDefault(e => e.Name == EditionManager.DefaultEditionName);
            if (defaultEdition == null)
            {
                defaultEdition = new Edition { Name = EditionManager.DefaultEditionName, DisplayName = EditionManager.DefaultEditionName };
                _context.Editions.Add(defaultEdition);
                _context.SaveChanges();

                //TODO: Add desired features to the standard edition, if wanted!
            }
        }
    }
}