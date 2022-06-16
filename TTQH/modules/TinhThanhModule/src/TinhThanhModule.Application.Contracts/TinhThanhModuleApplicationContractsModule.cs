using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace TinhThanhModule;

[DependsOn(
    typeof(TinhThanhModuleDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class TinhThanhModuleApplicationContractsModule : AbpModule
{

}
