using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace TinhThanhModule;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(TinhThanhModuleDomainSharedModule)
)]
public class TinhThanhModuleDomainModule : AbpModule
{

}
