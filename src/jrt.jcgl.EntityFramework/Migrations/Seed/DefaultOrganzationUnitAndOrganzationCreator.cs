using Abp.Organizations;
using jrt.jcgl.EntityFramework;
using jrt.jcgl.MultiTenancy;
using jrt.jcgl.Organizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jrt.jcgl.Migrations.Seed
{
    public class DefaultOrganzationUnitAndOrganzationCreator
    {
        private readonly AbpZeroTemplateDbContext _context;


        public DefaultOrganzationUnitAndOrganzationCreator(AbpZeroTemplateDbContext context)
        {
            _context = context;
        }

        public void Creat()
        {
            var defaultTenant = _context.Tenants.FirstOrDefault(t => t.TenancyName == Tenant.DefaultTenantName);
            var scx1 = InsertOrganzationUnit(defaultTenant, "1号生产线", "0001");
            if (scx1 != null)
            {
                InsertOrganization(scx1, OrganizationType.ProdutionLine);
                var tiqu = InsertOrganzationUnit(defaultTenant, "1号提取组", "0001.0001", scx1);
                if (tiqu != null)
                {
                    InsertOrganization(tiqu, OrganizationType.Extract);
                    var tiquno1 = InsertOrganzationUnit(defaultTenant, "1号提取组一组", "0001.0001.0001", tiqu);
                    InsertOrganization(tiquno1, OrganizationType.Extract);
                    var tiquno2 = InsertOrganzationUnit(defaultTenant, "1号提取组二组", "0001.0001.0002", tiqu);
                    InsertOrganization(tiquno2, OrganizationType.Extract);
                    var tiquno3 = InsertOrganzationUnit(defaultTenant, "1号提取组三组", "0001.0001.0003", tiqu);
                    InsertOrganization(tiquno3, OrganizationType.Extract);
                }
                var mo = InsertOrganzationUnit(defaultTenant, "1号膜组", "0001.0002", scx1);
                if (mo != null)
                {
                    InsertOrganization(mo, OrganizationType.Membrane);
                    var mono1 = InsertOrganzationUnit(defaultTenant, "1号膜一组", "0001.0002.0001", mo);
                    InsertOrganization(mono1, OrganizationType.Membrane);
                    var mono2 = InsertOrganzationUnit(defaultTenant, "1号膜二组", "0001.0002.0002", mo);
                    InsertOrganization(mono2, OrganizationType.Membrane);
                    var mono3 = InsertOrganzationUnit(defaultTenant, "1号膜三组", "0001.0002.0003", mo);
                    InsertOrganization(mono3, OrganizationType.Membrane);
                }
            }
            var scx2 = InsertOrganzationUnit(defaultTenant, "2号生产线", "0002");
            if (scx2 != null)
            {
                InsertOrganization(scx2, OrganizationType.ProdutionLine);
                var tiqu = InsertOrganzationUnit(defaultTenant, "2号提取组", "0002.0001", scx2);
                if (tiqu != null)
                {
                    InsertOrganization(tiqu, OrganizationType.Extract);
                    var tiquno1 = InsertOrganzationUnit(defaultTenant, "2号提取组一组", "0002.0001.0001", tiqu);
                    InsertOrganization(tiquno1, OrganizationType.Extract);
                    var tiquno2 = InsertOrganzationUnit(defaultTenant, "2号提取组二组", "0002.0001.0002", tiqu);
                    InsertOrganization(tiquno2, OrganizationType.Extract);
                    var tiquno3 = InsertOrganzationUnit(defaultTenant, "2号提取组三组", "0002.0001.0003", tiqu);
                    InsertOrganization(tiquno3, OrganizationType.Extract);
                }
                var mo = InsertOrganzationUnit(defaultTenant, "2号膜组", "0002.0002", scx2);
                if (mo != null)
                {
                    InsertOrganization(mo, OrganizationType.Membrane);
                    var mono1 = InsertOrganzationUnit(defaultTenant, "2号膜一组", "0002.0002.0001", mo);
                    InsertOrganization(mono1, OrganizationType.Membrane);
                    var mono2 = InsertOrganzationUnit(defaultTenant, "2号膜二组", "0002.0002.0002", mo);
                    InsertOrganization(mono2, OrganizationType.Membrane);
                    var mono3 = InsertOrganzationUnit(defaultTenant, "2号膜三组", "0002.0002.0003", mo);
                    InsertOrganization(mono3, OrganizationType.Membrane);
                }
            }
            //var tiqu = InsertOrganzationUnit(defaultTenant, "提取组", "0001");
            //if (tiqu != null)
            //{
            //    InsertOrganization(tiqu, OrganizationType.Extract);
            //    var tiquno1 = InsertOrganzationUnit(defaultTenant, "提取组一组", "0001.0001", tiqu);
            //    InsertOrganization(tiquno1, OrganizationType.Extract);
            //    var tiquno2 = InsertOrganzationUnit(defaultTenant, "提取组二组", "0001.0002", tiqu);
            //    InsertOrganization(tiquno2, OrganizationType.Extract);
            //    var tiquno3 = InsertOrganzationUnit(defaultTenant, "提取组三组", "0001.0003", tiqu);
            //    InsertOrganization(tiquno3, OrganizationType.Extract);
            //}

            //var mo = InsertOrganzationUnit(defaultTenant, "膜组", "0001");
            //if (mo != null)
            //{
            //    InsertOrganization(mo, OrganizationType.Membrane);
            //    var mono1 = InsertOrganzationUnit(defaultTenant, "膜一组", "0002.0001", mo);
            //    InsertOrganization(mono1, OrganizationType.Membrane);
            //    var mono2 = InsertOrganzationUnit(defaultTenant, "膜二组", "0002.0002", mo);
            //    InsertOrganization(mono2, OrganizationType.Membrane);
            //    var mono3 = InsertOrganzationUnit(defaultTenant, "膜三组", "0002.0003", mo);
            //    InsertOrganization(mono3, OrganizationType.Membrane);
            //}
        }

        private OrganizationUnit InsertOrganzationUnit(Tenant defaultTenant, string displayName, string code, OrganizationUnit Parent = null)
        {
            OrganizationUnit o = null;
            var defaultOrganzation = _context.OrganizationUnits.FirstOrDefault(u => u.DisplayName == displayName);
            if (defaultOrganzation != null)
                return o;
            if (Parent != null)
                o = _context.OrganizationUnits.Add(new OrganizationUnit
                {
                    TenantId = defaultTenant.Id,
                    ParentId = Parent.Id,
                    Code = code,
                    DisplayName = displayName,
                    IsDeleted = false,
                    CreationTime = DateTime.Now
                });
            else
                o = _context.OrganizationUnits.Add(new OrganizationUnit
                {
                    TenantId = defaultTenant.Id,
                    Code = code,
                    DisplayName = displayName,
                    IsDeleted = false,
                    CreationTime = DateTime.Now
                });
            _context.SaveChanges();
            return o;
        }

        private Organization InsertOrganization(OrganizationUnit organizationUnit, OrganizationType type)
        {
            var defaultOrganzation = _context.Organizations.Add(new Organization
            {
                OrganizationUnitId = organizationUnit.Id,
                Type = type,
                IsDeleted = false,
                CreationTime = DateTime.Now
            });
            _context.SaveChanges();
            return defaultOrganzation;
        }
    }
}
