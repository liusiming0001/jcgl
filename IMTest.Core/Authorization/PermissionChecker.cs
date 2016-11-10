using Abp.Authorization;
using IMTest.Authorization.Roles;
using IMTest.MultiTenancy;
using IMTest.Users;

namespace IMTest.Authorization
{
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
