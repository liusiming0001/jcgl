using Abp.Organizations;
using jrt.jcgl.EntityFramework;
using jrt.jcgl.MultiTenancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jrt.jcgl.Migrations.Seed
{
    public class DefaultOrganizationsCreator
    {
        private string[] tiquzudisplayname = new string[] { "提取工作组", "提取一组", "提取二组", "提取三组" };
        private string[] mozudisplayname = new string[] { "膜工作组", "膜一组", "膜二组", "膜三组" };

        private readonly AbpZeroTemplateDbContext _context;

        public DefaultOrganizationsCreator(AbpZeroTemplateDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateOrganzationUnitsAndOrganization();
        }

        private void CreateOrganzationUnitsAndOrganization()
        {
            var defaultTenant = _context.Tenants.FirstOrDefault(t => t.TenancyName == Tenant.DefaultTenantName);
            var organtionunits = _context.OrganizationUnits.FirstOrDefault(o => o.DisplayName == tiquzudisplayname[0]);
            if (organtionunits == null)
            {
                organtionunits = _context.OrganizationUnits.Add(new OrganizationUnit
                {

                });
            }
        }

        private void AddOrganization(Tenant defaultTenant, OrganizationUnit parent, string displayname)
        {
            var organtionunits = _context.OrganizationUnits.FirstOrDefault(o => o.DisplayName == displayname);
            if (organtionunits == null)
            {
                organtionunits = _context.OrganizationUnits.Add(new OrganizationUnit
                {

                });
            }
        }
    }
}
