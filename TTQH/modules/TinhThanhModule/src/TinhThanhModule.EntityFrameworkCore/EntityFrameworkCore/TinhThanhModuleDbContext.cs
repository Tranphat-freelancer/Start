using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace TinhThanhModule.EntityFrameworkCore;

[ConnectionStringName(TinhThanhModuleDbProperties.ConnectionStringName)]
public class TinhThanhModuleDbContext : AbpDbContext<TinhThanhModuleDbContext>, ITinhThanhModuleDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public TinhThanhModuleDbContext(DbContextOptions<TinhThanhModuleDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureTinhThanhModule();
    }
}
