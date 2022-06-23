using Volo.Abp.Reflection;

namespace TinhThanhModule.Permissions;

public class TinhThanhModulePermissions
{
    public const string GroupName = "TinhThanhModule";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(TinhThanhModulePermissions));
    }
}
