using QuanHuyenModule.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace QuanHuyenModule.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class QuanHuyenModulePageModel : AbpPageModel
{
    protected QuanHuyenModulePageModel()
    {
        LocalizationResourceType = typeof(QuanHuyenModuleResource);
        ObjectMapperContext = typeof(QuanHuyenModuleWebModule);
    }
}
