using TinhThanhModule.Localization;
using Volo.Abp.Application.Services;

namespace TinhThanhModule;

public abstract class TinhThanhModuleAppService : ApplicationService
{
    protected TinhThanhModuleAppService()
    {
        LocalizationResource = typeof(TinhThanhModuleResource);
        ObjectMapperContext = typeof(TinhThanhModuleApplicationModule);
    }
}
