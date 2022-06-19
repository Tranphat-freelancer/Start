using QuanHuyenModule.Localization;
using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace QuanHuyenModule.Web.Menus;

public class QuanHuyenModuleMenuContributor : IMenuContributor
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
        var l = context.GetLocalizer<QuanHuyenModuleResource>();

        //Add main menu items.
        context.Menu.AddItem(
            new ApplicationMenuItem(
                QuanHuyenModuleMenus.Prefix,
                l["Menu:QuanHuyenModule"],
                icon: "fa fa-global"
            ).AddItem(
                new ApplicationMenuItem(
                   QuanHuyenModuleMenus.QuanHuyen,
                    l["Menu:QuanHuyen"],
                    url: "/QuanHuyens"
                )
            )
        );

        return Task.CompletedTask;
    }
}
