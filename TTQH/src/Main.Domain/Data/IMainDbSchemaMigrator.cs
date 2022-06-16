using System.Threading.Tasks;

namespace Main.Data;

public interface IMainDbSchemaMigrator
{
    Task MigrateAsync();
}
