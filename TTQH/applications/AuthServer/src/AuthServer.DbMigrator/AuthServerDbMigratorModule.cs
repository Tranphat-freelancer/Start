using AuthServer.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace AuthServer.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AuthServerEntityFrameworkCoreModule)
    )]
public class AuthServerDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
