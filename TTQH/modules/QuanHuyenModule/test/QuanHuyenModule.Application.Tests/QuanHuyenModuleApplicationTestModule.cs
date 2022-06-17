using Volo.Abp.Modularity;

namespace QuanHuyenModule;

[DependsOn(
    typeof(QuanHuyenModuleApplicationModule),
    typeof(QuanHuyenModuleDomainTestModule)
    )]
public class QuanHuyenModuleApplicationTestModule : AbpModule
{

}
