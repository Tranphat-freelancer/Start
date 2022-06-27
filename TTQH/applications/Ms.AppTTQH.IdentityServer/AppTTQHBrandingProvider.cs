using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Ms.AppTTQH;

[Dependency(ReplaceServices = true)]
public class AppTTQHBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "AppTTQH";
}
