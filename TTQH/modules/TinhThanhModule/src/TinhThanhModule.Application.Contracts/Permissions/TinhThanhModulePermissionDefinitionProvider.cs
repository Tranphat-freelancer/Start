using TinhThanhModule.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace TinhThanhModule.Permissions;

public class TinhThanhModulePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(TinhThanhModulePermissions.GroupName, L("Permission:TinhThanhModule"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<TinhThanhModuleResource>(name);
    }
}
