using Volo.Abp.Settings;

namespace NRSoft.CloudBackup.Settings
{
    public class CloudBackupSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(CloudBackupSettings.MySetting1));
        }
    }
}
