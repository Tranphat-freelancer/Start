using QuanHuyenModule.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace QuanHuyenModule;

public abstract class QuanHuyenModuleController : AbpControllerBase
{
    protected QuanHuyenModuleController()
    {
        LocalizationResource = typeof(QuanHuyenModuleResource);
    }
}
