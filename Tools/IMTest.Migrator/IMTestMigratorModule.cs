using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using IMTest.EntityFramework;

namespace IMTest.Migrator
{
    [DependsOn(typeof(IMTestDataModule))]
    public class IMTestMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<IMTestDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}