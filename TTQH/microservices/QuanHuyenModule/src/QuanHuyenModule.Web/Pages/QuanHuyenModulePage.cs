using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Microsoft.Extensions.Localization;
using QuanHuyenModule.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace QuanHuyenModule.Web.Pages;

public abstract class QuanHuyenModulePage : AbpPage
{
    [RazorInject]
    public IStringLocalizer<QuanHuyenModuleResource> L { get; set; }
}
