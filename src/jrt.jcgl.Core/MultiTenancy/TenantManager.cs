using Abp.Domain.Repositories;
using Abp.MultiTenancy;
using jrt.jcgl.Authorization.Roles;
using jrt.jcgl.Authorization.Users;
using jrt.jcgl.Editions;

namespace jrt.jcgl.MultiTenancy
{
    /// <summary>
    /// Tenant manager.
    /// </summary>
    public class TenantManager : AbpTenantManager<Tenant, Role, User>
    {
        public TenantManager(
            IRepository<Tenant> tenantRepository, 
            IRepository<TenantFeatureSetting, long> tenantFeatureRepository, 
            EditionManager editionManager) : 
            base(
                tenantRepository, 
                tenantFeatureRepository, 
                editionManager
            )
        {
        }
    }
}
