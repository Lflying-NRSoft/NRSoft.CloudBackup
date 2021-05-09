using NRSoft.CloudBackup.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace NRSoft.CloudBackup.Permissions
{
    public class CloudBackupPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(CloudBackupPermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(CloudBackupPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<CloudBackupResource>(name);
        }
    }
}
