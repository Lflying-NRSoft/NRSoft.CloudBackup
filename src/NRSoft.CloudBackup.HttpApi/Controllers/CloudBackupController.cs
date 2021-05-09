using NRSoft.CloudBackup.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace NRSoft.CloudBackup.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class CloudBackupController : AbpController
    {
        protected CloudBackupController()
        {
            LocalizationResource = typeof(CloudBackupResource);
        }
    }
}