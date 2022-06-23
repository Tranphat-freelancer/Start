using TinhThanhModule.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace TinhThanhModule;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(TinhThanhModuleEntityFrameworkCoreTestModule)
    )]
public class TinhThanhModuleDomainTestModule : AbpModule
{

}
