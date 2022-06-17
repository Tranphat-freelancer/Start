using Volo.Abp.Reflection;

namespace QuanHuyenModule.Permissions;

public class QuanHuyenModulePermissions
{
    public const string GroupName = "QuanHuyenModule";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(QuanHuyenModulePermissions));
    }
}
