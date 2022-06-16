using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace TinhThanhModule.Web.Menus;

public class TinhThanhModuleMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        //Add main menu items.
        context.Menu.AddItem(new ApplicationMenuItem(TinhThanhModuleMenus.Prefix, displayName: "TinhThanhModule", "~/TinhThanhModule", icon: "fa fa-globe"));

        return Task.CompletedTask;
    }
}
