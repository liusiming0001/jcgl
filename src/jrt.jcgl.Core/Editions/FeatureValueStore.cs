using Abp.Application.Features;
using jrt.jcgl.Authorization.Roles;
using jrt.jcgl.Authorization.Users;
using jrt.jcgl.MultiTenancy;

namespace jrt.jcgl.Editions
{
    public class FeatureValueStore : AbpFeatureValueStore<Tenant, Role, User>
    {
        public FeatureValueStore(TenantManager tenantManager) 
            : base(tenantManager)
        {
        }
    }
}
