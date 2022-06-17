using Localization.Resources.AbpUi;
using QuanHuyenModule.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace QuanHuyenModule;

[DependsOn(
    typeof(QuanHuyenModuleApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class QuanHuyenModuleHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(QuanHuyenModuleHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<QuanHuyenModuleResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
