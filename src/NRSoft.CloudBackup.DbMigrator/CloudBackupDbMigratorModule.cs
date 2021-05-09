using NRSoft.CloudBackup.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace NRSoft.CloudBackup.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(CloudBackupEntityFrameworkCoreDbMigrationsModule),
        typeof(CloudBackupApplicationContractsModule)
        )]
    public class CloudBackupDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
