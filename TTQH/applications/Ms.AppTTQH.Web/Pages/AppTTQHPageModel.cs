using Ms.Shared.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Ms.AppTTQH.Web.Pages;

public abstract class AppTTQHPageModel : AbpPageModel
{
    protected AppTTQHPageModel()
    {
        LocalizationResourceType = typeof(AppTTQHResource); 
        //ObjectMapperContext = typeof(AppTTQHWebModule);
    }
}
