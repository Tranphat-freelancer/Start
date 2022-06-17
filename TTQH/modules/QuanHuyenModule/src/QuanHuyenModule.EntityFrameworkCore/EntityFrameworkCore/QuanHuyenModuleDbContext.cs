using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace QuanHuyenModule.EntityFrameworkCore;

[ConnectionStringName(QuanHuyenModuleDbProperties.ConnectionStringName)]
public class QuanHuyenModuleDbContext : AbpDbContext<QuanHuyenModuleDbContext>, IQuanHuyenModuleDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public QuanHuyenModuleDbContext(DbContextOptions<QuanHuyenModuleDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureQuanHuyenModule();
    }
}
