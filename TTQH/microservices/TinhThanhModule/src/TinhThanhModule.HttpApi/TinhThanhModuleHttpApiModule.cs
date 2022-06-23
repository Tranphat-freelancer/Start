using Localization.Resources.AbpUi;
using TinhThanhModule.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace TinhThanhModule;

[DependsOn(
    typeof(TinhThanhModuleApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class TinhThanhModuleHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(TinhThanhModuleHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<TinhThanhModuleResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
