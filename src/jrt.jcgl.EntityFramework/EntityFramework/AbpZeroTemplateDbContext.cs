using System.Data.Common;
using System.Data.Entity;
using Abp.Zero.EntityFramework;
using jrt.jcgl.Authorization.Roles;
using jrt.jcgl.Authorization.Users;
using jrt.jcgl.MultiTenancy;
using jrt.jcgl.Storage;
using jrt.jcgl.Schedulings;
using jrt.jcgl.Organizations;
using jrt.jcgl.CustomHolidays;
using jrt.jcgl.ProductionPlans;
using jrt.jcgl.RawMaterials;
using jrt.jcgl.Stocks;

namespace jrt.jcgl.EntityFramework
{
    public class AbpZeroTemplateDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        /* Define an IDbSet for each entity of the application */
        public virtual IDbSet<Scheduling> Schedulings { get; set; }
        public virtual IDbSet<BinaryObject> BinaryObjects { get; set; }
        public virtual IDbSet<CustomHoliday> CustomHolidays { get; set; }
        public virtual IDbSet<Organization> Organizations { get; set; }

        public virtual IDbSet<ProductionBatchDetail> ProductionBatchDetails { get; set; }
        public virtual IDbSet<ProductionPlan> ProductionPlans { get; set; }
        public virtual IDbSet<ProductionPlanAudit> ProductionPlanAudits { get; set; }
        public virtual IDbSet<ProduictPlanLine> ProduictPlanLines { get; set; }
        public virtual IDbSet<ProdutionPlanMain> ProdutionPlanMains { get; set; }
        public virtual IDbSet<RawMaterial> RawMaterials { get; set; }
        public virtual IDbSet<RawMaterialConstant> RawMaterialConstants { get; set; }
        public virtual IDbSet<Stock> Stocks { get; set; }
        public virtual IDbSet<StockLog> StockLogs { get; set; }


        /* Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         * But it may cause problems when working Migrate.exe of EF. ABP works either way.         * 
         */
        public AbpZeroTemplateDbContext()
            : base("Default")
        {

        }

        /* This constructor is used by ABP to pass connection string defined in AbpZeroTemplateDataModule.PreInitialize.
         * Notice that, actually you will not directly create an instance of AbpZeroTemplateDbContext since ABP automatically handles it.
         */
        public AbpZeroTemplateDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        /* This constructor is used in tests to pass a fake/mock connection.
         */
        public AbpZeroTemplateDbContext(DbConnection dbConnection)
            : base(dbConnection, true)
        {

        }
    }
}
