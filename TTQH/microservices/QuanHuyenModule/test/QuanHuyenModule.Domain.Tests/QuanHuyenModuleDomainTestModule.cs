using QuanHuyenModule.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace QuanHuyenModule;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(QuanHuyenModuleEntityFrameworkCoreTestModule)
    )]
public class QuanHuyenModuleDomainTestModule : AbpModule
{

}
