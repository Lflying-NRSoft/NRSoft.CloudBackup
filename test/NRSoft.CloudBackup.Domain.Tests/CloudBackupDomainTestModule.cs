using NRSoft.CloudBackup.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace NRSoft.CloudBackup
{
    [DependsOn(
        typeof(CloudBackupEntityFrameworkCoreTestModule)
        )]
    public class CloudBackupDomainTestModule : AbpModule
    {

    }
}