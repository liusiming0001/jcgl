using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Runtime.Caching;
using Abp.Zero.Configuration;
using jrt.jcgl.Authorization.Users;
using jrt.jcgl.MultiTenancy;

namespace jrt.jcgl.Authorization.Roles
{
    /// <summary>
    /// Role manager.
    /// Used to implement domain logic for roles.
    /// </summary>
    public class RoleManager : AbpRoleManager<Tenant, Role, User>
    {
        public RoleManager(RoleStore store, IPermissionManager permissionManager, IRoleManagementConfig roleManagementConfig, ICacheManager cacheManager)
            : base(store, permissionManager, roleManagementConfig, cacheManager)
        {
            
        }
    }
}