using Main.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Main;

[DependsOn(
    typeof(MainEntityFrameworkCoreTestModule)
    )]
public class MainDomainTestModule : AbpModule
{

}
