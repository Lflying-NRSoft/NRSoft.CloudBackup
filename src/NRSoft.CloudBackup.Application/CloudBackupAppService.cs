using System;
using System.Collections.Generic;
using System.Text;
using NRSoft.CloudBackup.Localization;
using Volo.Abp.Application.Services;

namespace NRSoft.CloudBackup
{
    /* Inherit your application services from this class.
     */
    public abstract class CloudBackupAppService : ApplicationService
    {
        protected CloudBackupAppService()
        {
            LocalizationResource = typeof(CloudBackupResource);
        }
    }
}
