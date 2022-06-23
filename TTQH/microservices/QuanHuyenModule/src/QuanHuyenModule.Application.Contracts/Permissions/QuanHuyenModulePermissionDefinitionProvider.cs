using QuanHuyenModule.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace QuanHuyenModule.Permissions;

public class QuanHuyenModulePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(QuanHuyenModulePermissions.GroupName, L("Permission:QuanHuyenModule"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<QuanHuyenModuleResource>(name);
    }
}
