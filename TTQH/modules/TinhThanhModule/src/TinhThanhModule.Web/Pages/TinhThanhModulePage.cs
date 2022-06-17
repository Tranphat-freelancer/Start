using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Microsoft.Extensions.Localization;
using TinhThanhModule.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace TinhThanhModule.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class TinhThanhModulePage : AbpPage
{
    [RazorInject]
    //public IHtmlLocalizer<TinhThanhModuleResource> L { get; set; }
    public IStringLocalizer<TinhThanhModuleResource> L { get; set; }
}
