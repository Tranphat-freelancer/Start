using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Tasky.Administration.EntityFrameworkCore;
using Tasky.IdentityService.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Uow;

namespace Ms.DbMigrator;

public class MsDbMigrationService : ITransientDependency
{
    private readonly ICurrentTenant _currentTenant;
    private readonly IDataSeeder _dataSeeder;
    private readonly ILogger<MsDbMigrationService> _logger;
    private readonly IUnitOfWorkManager _unitOfWorkManager;

    public MsDbMigrationService(
        ILogger<MsDbMigrationService> logger,
        IDataSeeder dataSeeder,
        ICurrentTenant currentTenant,
        IUnitOfWorkManager unitOfWorkManager)
    {
        _logger = logger;
        _dataSeeder = dataSeeder;
        _currentTenant = currentTenant;
        _unitOfWorkManager = unitOfWorkManager;
    }

    public async Task MigrateAsync(CancellationToken cancellationToken)
    {
        await MigrateHostAsync(cancellationToken);
        _logger.LogInformation("Migration completed!");
    }

    private async Task MigrateHostAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Migrating Host side...");
        await MigrateAllDatabasesAsync(null, cancellationToken);
        await SeedDataAsync();
    }

    private async Task MigrateAllDatabasesAsync(
        Guid? tenantId,
        CancellationToken cancellationToken)
    {
        using (var uow = _unitOfWorkManager.Begin(true))
        {


            await MigrateDatabaseAsync<AdministrationDbContext>(cancellationToken);
            await MigrateDatabaseAsync<IdentityServiceDbContext>(cancellationToken);

            await uow.CompleteAsync(cancellationToken);
        }

        _logger.LogInformation(
            $"All databases have been successfully migrated ({(tenantId.HasValue ? $"tenantId: {tenantId}" : "HOST")}).");
    }

    private async Task MigrateDatabaseAsync<TDbContext>(
        CancellationToken cancellationToken)
        where TDbContext : DbContext, IEfCoreDbContext
    {
        _logger.LogInformation($"Migrating {typeof(TDbContext).Name.RemovePostFix("DbContext")} database...");

        var dbContext = await _unitOfWorkManager.Current.ServiceProvider
            .GetRequiredService<IDbContextProvider<TDbContext>>()
            .GetDbContextAsync();

        await dbContext
            .Database
            .MigrateAsync(cancellationToken);
    }

    private async Task SeedDataAsync()
    {
        await _dataSeeder.SeedAsync(
            new DataSeedContext(_currentTenant.Id)
                .WithProperty(IdentityDataSeedContributor.AdminEmailPropertyName, "admin@abp.io")
                .WithProperty(IdentityDataSeedContributor.AdminPasswordPropertyName, "1q2w3E*")
        );
    }
}