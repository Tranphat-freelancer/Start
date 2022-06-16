using Main.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Main.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(MainEntityFrameworkCoreModule),
    typeof(MainApplicationContractsModule)
    )]
public class MainDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
