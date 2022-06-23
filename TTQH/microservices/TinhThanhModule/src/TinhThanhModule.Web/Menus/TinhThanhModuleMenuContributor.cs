using System.Threading.Tasks;
using TinhThanhModule.Localization;
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
        var l = context.GetLocalizer<TinhThanhModuleResource>();

        //Add main menu items.
        context.Menu.AddItem(
            new ApplicationMenuItem(
                TinhThanhModuleMenus.Prefix,
                l["Menu:TinhThanhModule"],
                icon: "fa fa-global"
            ).AddItem(
                new ApplicationMenuItem(
                   TinhThanhModuleMenus.TinhThanh,
                    l["Menu:TinhThanh"],
                    url: "/TinhThanhs"
                )
            )
        );

        return Task.CompletedTask;
    }
}
