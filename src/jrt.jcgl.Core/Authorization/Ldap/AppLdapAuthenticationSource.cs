using Abp.Zero.Ldap.Authentication;
using Abp.Zero.Ldap.Configuration;
using jrt.jcgl.Authorization.Users;
using jrt.jcgl.MultiTenancy;

namespace jrt.jcgl.Authorization.Ldap
{
    public class AppLdapAuthenticationSource : LdapAuthenticationSource<Tenant, User>
    {
        public AppLdapAuthenticationSource(ILdapSettings settings, IAbpZeroLdapModuleConfig ldapModuleConfig)
            : base(settings, ldapModuleConfig)
        {
        }
    }
}
