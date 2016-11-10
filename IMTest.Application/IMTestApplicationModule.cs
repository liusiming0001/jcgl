using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;

namespace IMTest
{
    [DependsOn(typeof(IMTestCoreModule), typeof(AbpAutoMapperModule))]
    public class IMTestApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
