using NRSoft.CloudBackup.Localization;
using Volo.Abp.AspNetCore.Components;

namespace NRSoft.CloudBackup.Blazor
{
    public abstract class CloudBackupComponentBase : AbpComponentBase
    {
        protected CloudBackupComponentBase()
        {
            LocalizationResource = typeof(CloudBackupResource);
        }
    }
}
