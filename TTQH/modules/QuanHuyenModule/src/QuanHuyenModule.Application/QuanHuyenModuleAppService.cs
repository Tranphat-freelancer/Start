using QuanHuyenModule.Localization;
using Volo.Abp.Application.Services;

namespace QuanHuyenModule;

public abstract class QuanHuyenModuleAppService : ApplicationService
{
    protected QuanHuyenModuleAppService()
    {
        LocalizationResource = typeof(QuanHuyenModuleResource);
        ObjectMapperContext = typeof(QuanHuyenModuleApplicationModule);
    }
}
