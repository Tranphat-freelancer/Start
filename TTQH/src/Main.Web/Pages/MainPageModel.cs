using Main.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Main.Web.Pages;

public abstract class MainPageModel : AbpPageModel
{
    protected MainPageModel()
    {   
        LocalizationResourceType = typeof(MainResource);
    }
}
