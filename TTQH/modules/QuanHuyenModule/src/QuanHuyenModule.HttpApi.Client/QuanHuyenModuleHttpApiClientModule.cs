using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace QuanHuyenModule;

[DependsOn(
    typeof(QuanHuyenModuleApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class QuanHuyenModuleHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(QuanHuyenModuleApplicationContractsModule).Assembly,
            QuanHuyenModuleRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<QuanHuyenModuleHttpApiClientModule>();
        });

    }
}
