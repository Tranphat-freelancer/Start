using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace QuanHuyenModule.EntityFrameworkCore;

[DependsOn(
    typeof(QuanHuyenModuleDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class QuanHuyenModuleEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<QuanHuyenModuleDbContext>(options =>
        {
            /* Add custom repositories here. Example:
             * options.AddRepository<Question, EfCoreQuestionRepository>();
             */
            options.AddDefaultRepositories(includeAllEntities: true);
        });
        Configure<AbpDbContextOptions>(options =>
        {
            options.UseSqlServer();
        });
    }
}
