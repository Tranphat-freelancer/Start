using TinhThanhModule.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace TinhThanhModule.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class TinhThanhModulePageModel : AbpPageModel
{
    protected TinhThanhModulePageModel()
    {
        LocalizationResourceType = typeof(TinhThanhModuleResource);
        ObjectMapperContext = typeof(TinhThanhModuleWebModule);
    }
}
