using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace QuanHuyenModule;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(QuanHuyenModuleHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class QuanHuyenModuleConsoleApiClientModule : AbpModule
{

}
