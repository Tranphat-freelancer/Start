using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace TinhThanhModule;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(TinhThanhModuleHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class TinhThanhModuleConsoleApiClientModule : AbpModule
{

}
