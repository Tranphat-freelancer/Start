using Volo.Abp.Settings;

namespace Main.Settings;

public class MainSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(MainSettings.MySetting1));
    }
}
