using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace QuanHuyenModule;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(QuanHuyenModuleDomainSharedModule)
)]
public class QuanHuyenModuleDomainModule : AbpModule
{

}
