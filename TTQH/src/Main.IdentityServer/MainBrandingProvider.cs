using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Main;

[Dependency(ReplaceServices = true)]
public class MainBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Main";
}
