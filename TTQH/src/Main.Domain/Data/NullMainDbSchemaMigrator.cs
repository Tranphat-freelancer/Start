using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Main.Data;

/* This is used if database provider does't define
 * IMainDbSchemaMigrator implementation.
 */
public class NullMainDbSchemaMigrator : IMainDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
