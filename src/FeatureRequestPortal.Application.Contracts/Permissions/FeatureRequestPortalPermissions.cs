namespace FeatureRequestPortal.Permissions;

public static class FeatureRequestPortalPermissions
{
    public const string GroupName = "FeatureRequestPortal";

    //Add your own permission names. Example:
    //public const string MyPermission1 = GroupName + ".MyPermission1";

    public const string Manage = GroupName + ".FeatureRequests";
    public const string Update = Manage + ".Update";
    public const string Delete = Manage + ".Delete";
}
