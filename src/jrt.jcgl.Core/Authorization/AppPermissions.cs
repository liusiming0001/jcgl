namespace jrt.jcgl.Authorization
{
    /// <summary>
    /// Defines string constants for application's permission names.
    /// <see cref="AppAuthorizationProvider"/> for permission definitions.
    /// </summary>
    public static class AppPermissions
    {
        //COMMON PERMISSIONS (FOR BOTH OF TENANTS AND HOST)

        public const string Pages = "Pages";

        public const string Pages_Administration = "Pages.Administration";

        public const string Pages_Administration_Roles = "Pages.Administration.Roles";
        public const string Pages_Administration_Roles_Create = "Pages.Administration.Roles.Create";
        public const string Pages_Administration_Roles_Edit = "Pages.Administration.Roles.Edit";
        public const string Pages_Administration_Roles_Delete = "Pages.Administration.Roles.Delete";

        public const string Pages_Administration_Users = "Pages.Administration.Users";
        public const string Pages_Administration_Users_Create = "Pages.Administration.Users.Create";
        public const string Pages_Administration_Users_Edit = "Pages.Administration.Users.Edit";
        public const string Pages_Administration_Users_Delete = "Pages.Administration.Users.Delete";
        public const string Pages_Administration_Users_ChangePermissions = "Pages.Administration.Users.ChangePermissions";
        public const string Pages_Administration_Users_Impersonation = "Pages.Administration.Users.Impersonation";

        public const string Pages_Administration_Languages = "Pages.Administration.Languages";
        public const string Pages_Administration_Languages_Create = "Pages.Administration.Languages.Create";
        public const string Pages_Administration_Languages_Edit = "Pages.Administration.Languages.Edit";
        public const string Pages_Administration_Languages_Delete = "Pages.Administration.Languages.Delete";
        public const string Pages_Administration_Languages_ChangeTexts = "Pages.Administration.Languages.ChangeTexts";

        public const string Pages_Administration_AuditLogs = "Pages.Administration.AuditLogs";

        public const string Pages_Administration_OrganizationUnits = "Pages.Administration.OrganizationUnits";
        public const string Pages_Administration_OrganizationUnits_ManageOrganizationTree = "Pages.Administration.OrganizationUnits.ManageOrganizationTree";
        public const string Pages_Administration_OrganizationUnits_ManageMembers = "Pages.Administration.OrganizationUnits.ManageMembers";


        //TENANT-SPECIFIC PERMISSIONS

        public const string Pages_Tenant_Dashboard = "Pages.Tenant.Dashboard";

        public const string Pages_Administration_Tenant_Settings = "Pages.Administration.Tenant.Settings";

        //HOST-SPECIFIC PERMISSIONS

        public const string Pages_Editions = "Pages.Editions";
        public const string Pages_Editions_Create = "Pages.Editions.Create";
        public const string Pages_Editions_Edit = "Pages.Editions.Edit";
        public const string Pages_Editions_Delete = "Pages.Editions.Delete";

        public const string Pages_Tenants = "Pages.Tenants";
        public const string Pages_Tenants_Create = "Pages.Tenants.Create";
        public const string Pages_Tenants_Edit = "Pages.Tenants.Edit";
        public const string Pages_Tenants_ChangeFeatures = "Pages.Tenants.ChangeFeatures";
        public const string Pages_Tenants_Delete = "Pages.Tenants.Delete";
        public const string Pages_Tenants_Impersonation = "Pages.Tenants.Impersonation";

        public const string Pages_Administration_Host_Settings = "Pages.Administration.Host.Settings";


        /// <summary>
        /// 排班管理权限
        /// </summary>
        public const string Pages_ProductionManagers_SchedulingsManagers = "Pages.ProductionManagers.SchedulingsManagers";
        public const string Pages_ProductionManagers_Schedulings = "Pages.ProductionManagers.Schedulings";
        public const string Pages_ProductionManagers_Schedulings_Create = "Pages.ProductionManagers.Schedulings.Create";
        public const string Pages_ProductionManagers_SchedulingsDay = "Pages.ProductionManagers.SchedulingsDay";
        /// <summary>
        /// 自定义假期管理
        /// </summary>
        public const string Pages_ProductionManagers_CustomHolidays = "Pages.ProductionManagers.CustomHolidays";
        public const string Pages_ProductionManagers_CustomHolidays_Create = "Pages.ProductionManagers.CustomHolidays.Create";
        public const string Pages_ProductionManagers_CustomHolidays_Delete = "Pages.ProductionManagers.CustomHolidays.Delete";
        /// <summary>
        /// 根目录权限
        /// </summary>
        public const string Pages_ProductionManagers = "Pages.ProductionManagers ";
        public const string Pages_ProductionManagers_ProductionplanningAndSchedulings = "Pages.ProductionManagers.ProductionplanningAndSchedulings";
        public const string Pages_ProductionManagers_MaterielInfoManagers = "Pages.ProductionManagers.MaterielInfoManagers";
        /// <summary>
        /// 制定生产计划权限
        /// </summary>
        public const string Pages_ProductionManagers_MakingProductions = "Pages.ProductionManagers.MakingProductions";
        public const string Pages_ProductionManagers_MakingProductions_Create = "Pages.ProductionManagers.MakingProductions.Create";
        public const string Pages_ProductionManagers_MakingProductions_Delete = "Pages.ProductionManagers.MakingProductions.Delete";
        public const string Pages_ProductionManagers_MakingProductions_Edit = "Pages.ProductionManagers.MakingProductions.Edit";
        /// <summary>
        /// 审核生产计划权限
        /// </summary>
        public const string Pages_ProductionManagers_AuditProductions = "Pages.ProductionManagers.AuditProductions";
        public const string Pages_ProductionManagers_AuditProductions_Edit = "Pages.ProductionManagers.AuditProductions.Edit";
        /// <summary>
        /// 物料领取记录权限
        /// </summary>
        public const string Pages_ProductionManagers_MaterielLogs = "Pages.ProductionManagers.MaterielLogs";
        /// <summary>
        /// 生产计划执行权限
        /// </summary>
        public const string Pages_ProductionManagers_ExecuteProductions = "Pages.ProductionManagers.ExecuteProductions";
        public const string Pages_ProductionManagers_ExecuteProductions_Create = "Pages.ProductionManagers.ExecuteProductions.Create";
        public const string Pages_ProductionManagers_ExecuteProductions_Delete = "Pages.ProductionManagers.ExecuteProductions.Delete";
        public const string Pages_ProductionManagers_ExecuteProductions_Edit = "Pages.ProductionManagers.ExecuteProductions.Edit";
        /// <summary>
        /// 原料药信息管理权限
        /// </summary>
        public const string Pages_ProductionManagers_RawMaterialInfoManagers = "Pages.ProductionManagers.RawMaterialInfoManagers";
        public const string Pages_ProductionManagers_RawMaterialInfoManagers_Create = "Pages.ProductionManagers.RawMaterialInfoManagers.Create";
        public const string Pages_ProductionManagers_RawMaterialInfoManagers_Delete = "Pages.ProductionManagers.RawMaterialInfoManagers.Delete";
        public const string Pages_ProductionManagers_RawMaterialInfoManagers_Edit = "Pages.ProductionManagers.RawMaterialInfoManagers.Edit";
        /// <summary>
        /// 领回物料管理权限
        /// </summary>
        public const string Pages_ProductionManagers_GetBackMaterielInfoManagers = "Pages.ProductionManagers.GetBackMaterielInfoManagers";
        public const string Pages_ProductionManagers_GetBackMaterielInfoManagers_Create = "Pages.ProductionManagers.GetBackMaterielInfoManagers.Create";
        public const string Pages_ProductionManagers_GetBackMaterielInfoManagers_Delete = "Pages.ProductionManagers.GetBackMaterielInfoManagers.Delete";
        public const string Pages_ProductionManagers_GetBackMaterielInfoManagers_Edit = "Pages.ProductionManagers.GetBackMaterielInfoManages.Edit";

    }
}