using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.IdentityFramework;
using Abp.MultiTenancy;
using Abp.Runtime.Session;
using Microsoft.AspNet.Identity;
using jrt.jcgl.Authorization.Users;
using jrt.jcgl.MultiTenancy;
using Abp.Application.Services.Dto;
using System.Collections.Generic;

namespace jrt.jcgl
{
    /// <summary>
    /// All application services in this application is derived from this class.
    /// We can add common application service methods here.
    /// </summary>
    public abstract class AbpZeroTemplateAppServiceBase : ApplicationService
    {
        public TenantManager TenantManager { get; set; }

        public UserManager UserManager { get; set; }

        protected AbpZeroTemplateAppServiceBase()
        {
            LocalizationSourceName = AbpZeroTemplateConsts.LocalizationSourceName;
        }

        protected virtual Task<User> GetCurrentUserAsync()
        {
            var user = UserManager.FindByIdAsync(AbpSession.GetUserId());
            if (user == null)
            {
                throw new ApplicationException("There is no current user!");
            }

            return user;
        }

        protected virtual User GetCurrentUser()
        {
            var user = UserManager.FindById(AbpSession.GetUserId());
            if (user == null)
            {
                throw new ApplicationException("There is no current user!");
            }

            return user;
        }

        protected virtual Task<Tenant> GetCurrentTenantAsync()
        {
            return TenantManager.GetByIdAsync(AbpSession.GetTenantId());
        }

        protected virtual Tenant GetCurrentTenant()
        {
            return TenantManager.GetById(AbpSession.GetTenantId());
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
        protected virtual string GetLocalizedEnum<T>(T enumValue)
            where T : struct
        {
            if (!typeof(T).IsEnum) throw new ArgumentException("T must be an enumerated type");
            return L(ResourceName(typeof(T).ToString(), enumValue.ToString()));
        }
        protected virtual ListResultDto<NameValueDto> EnumToNameValueList<T>()
        {
            if (!typeof(T).IsEnum) throw new ArgumentException("T must be an enumerated type");

            List<NameValueDto> kv = new List<NameValueDto>();
            foreach (var en in Enum.GetValues(typeof(T)))
            {
                kv.Add(new NameValueDto
                {
                    Name = L(ResourceName(typeof(T).ToString(), Enum.GetName(typeof(T), en))),
                    Value = ((int)en).ToString(),
                });
            }
            return new ListResultDto<NameValueDto>(kv);
        }

        private string ResourceName(string packageName, string propertyName)
        {
            return string.Format("Enums.{0}.{1}", packageName, propertyName);
        }
    }
}