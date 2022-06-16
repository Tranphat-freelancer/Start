using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace TinhThanhModule;

[DependsOn(
    typeof(TinhThanhModuleApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class TinhThanhModuleHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(TinhThanhModuleApplicationContractsModule).Assembly,
            TinhThanhModuleRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<TinhThanhModuleHttpApiClientModule>();
        });

    }
}
