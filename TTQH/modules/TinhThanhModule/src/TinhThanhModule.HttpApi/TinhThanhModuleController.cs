using TinhThanhModule.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace TinhThanhModule;

public abstract class TinhThanhModuleController : AbpControllerBase
{
    protected TinhThanhModuleController()
    {
        LocalizationResource = typeof(TinhThanhModuleResource);
    }
}
