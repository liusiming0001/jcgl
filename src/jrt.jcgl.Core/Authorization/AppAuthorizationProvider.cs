using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace jrt.jcgl.Authorization
{
    /// <summary>
    /// Application's authorization provider.
    /// Defines permissions for the application.
    /// See <see cref="AppPermissions"/> for all permission names.
    /// </summary>
    public class AppAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //COMMON PERMISSIONS (FOR BOTH OF TENANTS AND HOST)

            var pages = context.GetPermissionOrNull(AppPermissions.Pages) ?? context.CreatePermission(AppPermissions.Pages, L("Pages"));

            var administration = pages.CreateChildPermission(AppPermissions.Pages_Administration, L("Administration"));

            var roles = administration.CreateChildPermission(AppPermissions.Pages_Administration_Roles, L("Roles"));
            roles.CreateChildPermission(AppPermissions.Pages_Administration_Roles_Create, L("CreatingNewRole"));
            roles.CreateChildPermission(AppPermissions.Pages_Administration_Roles_Edit, L("EditingRole"));
            roles.CreateChildPermission(AppPermissions.Pages_Administration_Roles_Delete, L("DeletingRole"));

            var users = administration.CreateChildPermission(AppPermissions.Pages_Administration_Users, L("Users"));
            users.CreateChildPermission(AppPermissions.Pages_Administration_Users_Create, L("CreatingNewUser"));
            users.CreateChildPermission(AppPermissions.Pages_Administration_Users_Edit, L("EditingUser"));
            users.CreateChildPermission(AppPermissions.Pages_Administration_Users_Delete, L("DeletingUser"));
            users.CreateChildPermission(AppPermissions.Pages_Administration_Users_ChangePermissions, L("ChangingPermissions"));
            users.CreateChildPermission(AppPermissions.Pages_Administration_Users_Impersonation, L("LoginForUsers"));

            var languages = administration.CreateChildPermission(AppPermissions.Pages_Administration_Languages, L("Languages"));
            languages.CreateChildPermission(AppPermissions.Pages_Administration_Languages_Create, L("CreatingNewLanguage"));
            languages.CreateChildPermission(AppPermissions.Pages_Administration_Languages_Edit, L("EditingLanguage"));
            languages.CreateChildPermission(AppPermissions.Pages_Administration_Languages_Delete, L("DeletingLanguages"));
            languages.CreateChildPermission(AppPermissions.Pages_Administration_Languages_ChangeTexts, L("ChangingTexts"));

            administration.CreateChildPermission(AppPermissions.Pages_Administration_AuditLogs, L("AuditLogs"));

            var organizationUnits = administration.CreateChildPermission(AppPermissions.Pages_Administration_OrganizationUnits, L("OrganizationUnits"));
            organizationUnits.CreateChildPermission(AppPermissions.Pages_Administration_OrganizationUnits_ManageOrganizationTree, L("ManagingOrganizationTree"));
            organizationUnits.CreateChildPermission(AppPermissions.Pages_Administration_OrganizationUnits_ManageMembers, L("ManagingMembers"));

            //TENANT-SPECIFIC PERMISSIONS

            pages.CreateChildPermission(AppPermissions.Pages_Tenant_Dashboard, L("Dashboard"), multiTenancySides: MultiTenancySides.Tenant);

            administration.CreateChildPermission(AppPermissions.Pages_Administration_Tenant_Settings, L("Settings"), multiTenancySides: MultiTenancySides.Tenant);

            //HOST-SPECIFIC PERMISSIONS

            var editions = pages.CreateChildPermission(AppPermissions.Pages_Editions, L("Editions"), multiTenancySides: MultiTenancySides.Host);
            editions.CreateChildPermission(AppPermissions.Pages_Editions_Create, L("CreatingNewEdition"), multiTenancySides: MultiTenancySides.Host);
            editions.CreateChildPermission(AppPermissions.Pages_Editions_Edit, L("EditingEdition"), multiTenancySides: MultiTenancySides.Host);
            editions.CreateChildPermission(AppPermissions.Pages_Editions_Delete, L("DeletingEdition"), multiTenancySides: MultiTenancySides.Host);

            var tenants = pages.CreateChildPermission(AppPermissions.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
            tenants.CreateChildPermission(AppPermissions.Pages_Tenants_Create, L("CreatingNewTenant"), multiTenancySides: MultiTenancySides.Host);
            tenants.CreateChildPermission(AppPermissions.Pages_Tenants_Edit, L("EditingTenant"), multiTenancySides: MultiTenancySides.Host);
            tenants.CreateChildPermission(AppPermissions.Pages_Tenants_ChangeFeatures, L("ChangingFeatures"), multiTenancySides: MultiTenancySides.Host);
            tenants.CreateChildPermission(AppPermissions.Pages_Tenants_Delete, L("DeletingTenant"), multiTenancySides: MultiTenancySides.Host);
            tenants.CreateChildPermission(AppPermissions.Pages_Tenants_Impersonation, L("LoginForTenants"), multiTenancySides: MultiTenancySides.Host);

            administration.CreateChildPermission(AppPermissions.Pages_Administration_Host_Settings, L("Settings"), multiTenancySides: MultiTenancySides.Host);

            //生产计划根目录
            var productionmanagers = pages.CreateChildPermission(AppPermissions.Pages_ProductionManagers, L("ProductionManagers"));
            var productionplanningandschedulings = productionmanagers.CreateChildPermission(AppPermissions.Pages_ProductionManagers_ProductionplanningAndSchedulings, L("ProductionplanningAndSchedulings"));
            var materielinfomanager = productionmanagers.CreateChildPermission(AppPermissions.Pages_ProductionManagers_MaterielInfoManagers, L("MaterielInfoManagers"));
            var schedulingsmanagers = productionmanagers.CreateChildPermission(AppPermissions.Pages_ProductionManagers_SchedulingsManagers, L("SchedulingsManagers"));
            //制定生产计划
            var makingproductions = productionplanningandschedulings.CreateChildPermission(AppPermissions.Pages_ProductionManagers_MakingProductions, L("MakingProductions"));
            makingproductions.CreateChildPermission(AppPermissions.Pages_ProductionManagers_MakingProductions_Create, L("CreateNewMakingProductions"));
            makingproductions.CreateChildPermission(AppPermissions.Pages_ProductionManagers_MakingProductions_Delete, L("DeletingMakingProductions"));
            makingproductions.CreateChildPermission(AppPermissions.Pages_ProductionManagers_MakingProductions_Edit, L("EditingMakingProductions"));

            var productionshistory = productionplanningandschedulings.CreateChildPermission(AppPermissions.Pages_ProductionManagers_ProductionsHistory, L("ProductionsHistory"));
            //审核生产计划
            var auditproduction = productionplanningandschedulings.CreateChildPermission(AppPermissions.Pages_ProductionManagers_AuditProductions, L("AuditProductions"));
            auditproduction.CreateChildPermission(AppPermissions.Pages_ProductionManagers_AuditProductions_Edit, L("EditingAuditProductions"));
            //物料领取记录
            var materiellog = productionplanningandschedulings.CreateChildPermission(AppPermissions.Pages_ProductionManagers_MaterielLogs, L("MaterielLogs"));
            //生产计划执行
            var executeproduction = productionmanagers.CreateChildPermission(AppPermissions.Pages_ProductionManagers_ExecuteProductions, L("ExecuteProductions"));
            executeproduction.CreateChildPermission(AppPermissions.Pages_ProductionManagers_ExecuteProductions_Create, L("CreateNewExecuteProductions"));
            executeproduction.CreateChildPermission(AppPermissions.Pages_ProductionManagers_ExecuteProductions_Delete, L("DeletingExecuteProductions"));
            executeproduction.CreateChildPermission(AppPermissions.Pages_ProductionManagers_ExecuteProductions_Edit, L("EditingExecuteProductions"));
            //物料信息
            var rawmaterialinfomanager = materielinfomanager.CreateChildPermission(AppPermissions.Pages_ProductionManagers_RawMaterialInfoManagers,L("RawMaterialInfoManagers"));
            rawmaterialinfomanager.CreateChildPermission(AppPermissions.Pages_ProductionManagers_RawMaterialInfoManagers_Create, L("CreateNewRawMaterialInfoManagers"));
            rawmaterialinfomanager.CreateChildPermission(AppPermissions.Pages_ProductionManagers_RawMaterialInfoManagers_Delete, L("DeletingRawMaterialInfoManagers"));
            rawmaterialinfomanager.CreateChildPermission(AppPermissions.Pages_ProductionManagers_RawMaterialInfoManagers_Edit, L("EditingRawMaterialInfoManagers"));
            //领回物料
            var getbackmaterielinfomanager = materielinfomanager.CreateChildPermission(AppPermissions.Pages_ProductionManagers_GetBackMaterielInfoManagers, L("GetBackMaterielInfoManagers"));
            getbackmaterielinfomanager.CreateChildPermission(AppPermissions.Pages_ProductionManagers_GetBackMaterielInfoManagers_Create, L("CreateNewGetBackMaterielInfoManagers"));
            getbackmaterielinfomanager.CreateChildPermission(AppPermissions.Pages_ProductionManagers_GetBackMaterielInfoManagers_Delete, L("DeletingGetBackMaterielInfoManagers"));
            getbackmaterielinfomanager.CreateChildPermission(AppPermissions.Pages_ProductionManagers_GetBackMaterielInfoManagers_Edit, L("EditingGetBackMaterielInfoManagers"));
            //排班
            var scheduling = schedulingsmanagers.CreateChildPermission(AppPermissions.Pages_ProductionManagers_Schedulings, L("Schedulings"));
            scheduling.CreateChildPermission(AppPermissions.Pages_ProductionManagers_Schedulings_Create, L("CreateNewSchedulings"));
            //排班日程
            var schedulingday = schedulingsmanagers.CreateChildPermission(AppPermissions.Pages_ProductionManagers_SchedulingsDay, L("SchedulingsDay"));
            //自定义假期
            var customHolidays = schedulingsmanagers.CreateChildPermission(AppPermissions.Pages_ProductionManagers_CustomHolidays, L("CustomHolidays"));
            customHolidays.CreateChildPermission(AppPermissions.Pages_ProductionManagers_CustomHolidays_Create, L("CustomHolidays.Create"));
            customHolidays.CreateChildPermission(AppPermissions.Pages_ProductionManagers_CustomHolidays_Delete, L("CustomHolidays.Delete"));
            //库存
            var stocks = materielinfomanager.CreateChildPermission(AppPermissions.Pages_ProductionManagers_Stocks,L("Stocks"));
            stocks.CreateChildPermission(AppPermissions.Pages_ProductionManagers_Stocks_Edit,L("Stocks.Edit"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, AbpZeroTemplateConsts.LocalizationSourceName);
        }
    }
}
