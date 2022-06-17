using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace QuanHuyenModule;

[DependsOn(
    typeof(QuanHuyenModuleDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class QuanHuyenModuleApplicationContractsModule : AbpModule
{

}
