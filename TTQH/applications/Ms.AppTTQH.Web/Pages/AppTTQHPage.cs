using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Microsoft.Extensions.Localization;
using Ms.Shared.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.Users;

namespace Ms.AppTTQH.Web.Pages;

public abstract class AppTTQHPage : AbpPage
{
    [RazorInject]
    //public IHtmlLocalizer<TinhThanhModuleResource> L { get; set; }
    public IStringLocalizer<AppTTQHResource> L { get; set; }
}
