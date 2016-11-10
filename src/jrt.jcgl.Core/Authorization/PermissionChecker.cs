using Abp.Authorization;
using jrt.jcgl.Authorization.Roles;
using jrt.jcgl.Authorization.Users;
using jrt.jcgl.MultiTenancy;

namespace jrt.jcgl.Authorization
{
    /// <summary>
    /// Implements <see cref="PermissionChecker"/>.
    /// </summary>
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
