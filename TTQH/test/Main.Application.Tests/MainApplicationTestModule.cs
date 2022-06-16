using Volo.Abp.Modularity;

namespace Main;

[DependsOn(
    typeof(MainApplicationModule),
    typeof(MainDomainTestModule)
    )]
public class MainApplicationTestModule : AbpModule
{

}
