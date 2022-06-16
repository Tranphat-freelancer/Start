using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace TinhThanhModule.EntityFrameworkCore;

[ConnectionStringName(TinhThanhModuleDbProperties.ConnectionStringName)]
public interface ITinhThanhModuleDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
