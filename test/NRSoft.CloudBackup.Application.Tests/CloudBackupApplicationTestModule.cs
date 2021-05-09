using Volo.Abp.Modularity;

namespace NRSoft.CloudBackup
{
    [DependsOn(
        typeof(CloudBackupApplicationModule),
        typeof(CloudBackupDomainTestModule)
        )]
    public class CloudBackupApplicationTestModule : AbpModule
    {

    }
}