using Microsoft.EntityFrameworkCore;
using QuanHuyenModule.QuanHuyens;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace QuanHuyenModule.EntityFrameworkCore;

public static class QuanHuyenModuleDbContextModelCreatingExtensions
{
    public static void ConfigureQuanHuyenModule(
        this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        /* Configure all entities here. Example:

        builder.Entity<Question>(b =>
        {
            //Configure table & schema name
            b.ToTable(QuanHuyenModuleDbProperties.DbTablePrefix + "Questions", QuanHuyenModuleDbProperties.DbSchema);

            b.ConfigureByConvention();

            //Properties
            b.Property(q => q.Title).IsRequired().HasMaxLength(QuestionConsts.MaxTitleLength);

            //Relations
            b.HasMany(question => question.Tags).WithOne().HasForeignKey(qt => qt.QuestionId);

            //Indexes
            b.HasIndex(q => q.CreationTime);
        });
        */
        builder.Entity<QuanHuyen>(b =>
        {
            //Configure table & schema name
            b.ToTable(QuanHuyenModuleDbProperties.DbTablePrefix + "QuanHuyens", QuanHuyenModuleDbProperties.DbSchema);

            b.ConfigureByConvention();
        });
    }
}
