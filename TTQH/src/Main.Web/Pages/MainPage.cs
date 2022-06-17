using Main.Localization;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Microsoft.Extensions.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Main.Web.Pages;

public abstract class MainPage : AbpPage
{
    [RazorInject]
    public IStringLocalizer<MainResource> L { get; set; }
}
