using FeatureRequestPortal.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace FeatureRequestPortal.Permissions;

public class FeatureRequestPortalPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(FeatureRequestPortalPermissions.GroupName);

        //Define your own permissions here. Example:
        //myGroup.AddPermission(FeatureRequestPortalPermissions.MyPermission1, L("Permission:MyPermission1"));

        myGroup.AddPermission(FeatureRequestPortalPermissions.Create, L("Permission:Create"));
        myGroup.AddPermission(FeatureRequestPortalPermissions.Update, L("Permission:Update"));
        myGroup.AddPermission(FeatureRequestPortalPermissions.Default, L("Permission:Default"));
        myGroup.AddPermission(FeatureRequestPortalPermissions.Delete, L("Permission:Delete"));

    }


    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<FeatureRequestPortalResource>(name);
    }
}
