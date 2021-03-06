using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.Extensions;
using Abp.Runtime.Validation;
using jrt.jcgl.Configuration.Host.Dto;

namespace jrt.jcgl.Configuration.Tenants.Dto
{
    public class TenantSettingsEditDto : IDoubleWayDto
    {
        public GeneralSettingsEditDto General { get; set; }

        [Required]
        public TenantUserManagementSettingsEditDto UserManagement { get; set; }

        public EmailSettingsEditDto Email { get; set; }

        public LdapSettingsEditDto Ldap { get; set; }
        [Required]
        public ProductionSettingEditDto ProductionSetting { get; set; }

        /// <summary>
        /// This validation is done for single-tenant applications.
        /// Because, these settings can only be set by tenant in a single-tenant application.
        /// </summary>
        public void ValidateHostSettings()
        {
            var validationErrors = new List<ValidationResult>();
            if (General == null)
            {
                validationErrors.Add(new ValidationResult("General settings can not be null", new[] { "General" }));
            }
            else
            {
                if (General.WebSiteRootAddress.IsNullOrEmpty())
                {
                    validationErrors.Add(new ValidationResult("General.WebSiteRootAddress can not be null or empty", new[] { "WebSiteRootAddress" }));
                }
            }

            if (Email == null)
            {
                validationErrors.Add(new ValidationResult("Email settings can not be null", new[] { "Email" }));
            }

            if (ProductionSetting == null)
            {
                validationErrors.Add(new ValidationResult("ProductionSetting settings can not be null", new[] { "ProductionSetting" }));
            }

            if (validationErrors.Count > 0)
            {
                throw new AbpValidationException("Method arguments are not valid! See ValidationErrors for details.", validationErrors);
            }
        }
    }
}