﻿using EntityFramework.DynamicFilters;
using jrt.jcgl.EntityFramework;

namespace jrt.jcgl.Migrations.Seed
{
    public class InitialDbBuilder
    {
        private readonly AbpZeroTemplateDbContext _context;

        public InitialDbBuilder(AbpZeroTemplateDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new DefaultTenantRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
            new DefaultOrganzationUnitAndOrganzationCreator(_context).Creat();

            _context.SaveChanges();
        }
    }
}
