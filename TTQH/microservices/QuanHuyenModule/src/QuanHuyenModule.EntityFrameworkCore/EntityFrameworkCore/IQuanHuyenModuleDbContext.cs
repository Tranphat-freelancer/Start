using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace QuanHuyenModule.EntityFrameworkCore;

[ConnectionStringName(QuanHuyenModuleDbProperties.ConnectionStringName)]
public interface IQuanHuyenModuleDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
