namespace jrt.jcgl.Web.Navigation
{
    public static class PageNames
    {
        public static class App
        {
            public static class Common
            {
                public const string Administration = "Administration";
                public const string Roles = "Administration.Roles";
                public const string Users = "Administration.Users";
                public const string AuditLogs = "Administration.AuditLogs";
                public const string OrganizationUnits = "Administration.OrganizationUnits";
                public const string Languages = "Administration.Languages";

                //public const string ProductionplanningAndSchedulings = "Administration.ProductionplanningAndSchedulings";

            }
            public static class ProductionManager
            {
                public const string ProductionManagers = "ProductionManagers";
                public const string ProductionplanningAndSchedulings = "ProductionManagers.ProductionplanningAndSchedulings";                
                public const string MakingProductions = "ProductionManagers.MakingProductions";
                public const string AuditProductions = "ProductionManagers.AuditProductions";
                public const string MaterielLogs = "ProductionManagers.MaterielLogs";
                public const string ExecuteProductions = "ProductionManagers.ExecuteProductions";
                public const string MaterielInfoManagers = "ProductionManagers.MaterielInfoManagers";
                public const string RawMaterialInfoManagers = "RawMaterialInfoManagers";
                public const string GetBackMaterielInfoManagers = "ProductionManagers.GetBackMaterielInfoManagers";
                public const string SchedulingsManagers = "ProductionManagers.SchedulingsManagers";
                public const string Schedulings = "ProductionManagers.Schedulings";
                public const string SchedulingsDay = "ProductionManagers.SchedulingsDay";
                public const string CustomHolidays = "ProductionManagers.CustomHolidays";
            }
            public static class Host
            {
                public const string Tenants = "Tenants";
                public const string Editions = "Editions";
                public const string Settings = "Administration.Settings.Host";
            }

            public static class Tenant
            {
                public const string Dashboard = "Dashboard.Tenant";
                public const string Settings = "Administration.Settings.Tenant";
            }
        }

        public static class Frontend
        {
            public const string Home = "Frontend.Home";
            public const string About = "Frontend.About";
        }
    }
}