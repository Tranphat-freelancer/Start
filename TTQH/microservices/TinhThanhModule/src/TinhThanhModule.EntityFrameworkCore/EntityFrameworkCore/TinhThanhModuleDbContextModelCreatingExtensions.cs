using Microsoft.EntityFrameworkCore;
using TinhThanhModule.TinhThanhs;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace TinhThanhModule.EntityFrameworkCore;

public static class TinhThanhModuleDbContextModelCreatingExtensions
{
    public static void ConfigureTinhThanhModule(
        this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        /* Configure all entities here. Example:

        builder.Entity<Question>(b =>
        {
            //Configure table & schema name
            b.ToTable(TinhThanhModuleDbProperties.DbTablePrefix + "Questions", TinhThanhModuleDbProperties.DbSchema);

            b.ConfigureByConvention();

            //Properties
            b.Property(q => q.Title).IsRequired().HasMaxLength(QuestionConsts.MaxTitleLength);

            //Relations
            b.HasMany(question => question.Tags).WithOne().HasForeignKey(qt => qt.QuestionId);

            //Indexes
            b.HasIndex(q => q.CreationTime);
        });
        */
        builder.Entity<TinhThanh>(b =>
        {
            //Configure table & schema name
            b.ToTable(TinhThanhModuleDbProperties.DbTablePrefix + "TinhThanhs", TinhThanhModuleDbProperties.DbSchema);

            b.ConfigureByConvention();
        });
    }
}
