using Ms.Shared.Hosting.TTQH;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Ms.AppTTQH.Web.Pages;

public abstract class AppTTQHPageModel : AbpPageModel
{
    protected AppTTQHPageModel()
    {
        LocalizationResourceType = typeof(AppTTQHResource);
    }
}
