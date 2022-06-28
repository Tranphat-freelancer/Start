using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace QuanHuyenModule;

//DI by Original Module
[DependsOn(
    typeof(AbpHttpClientModule)
    )]
//DI by themselves
[DependsOn(
    typeof(QuanHuyenModuleApplicationContractsModule)
    )]
//DI orther microservice
//[DependsOn(
//    typeof(TinhThanhModuleHttpApiClientModule)
//    )]
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
