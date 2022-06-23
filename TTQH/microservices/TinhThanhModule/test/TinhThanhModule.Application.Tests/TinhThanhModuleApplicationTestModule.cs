using Volo.Abp.Modularity;

namespace TinhThanhModule;

[DependsOn(
    typeof(TinhThanhModuleApplicationModule),
    typeof(TinhThanhModuleDomainTestModule)
    )]
public class TinhThanhModuleApplicationTestModule : AbpModule
{

}
