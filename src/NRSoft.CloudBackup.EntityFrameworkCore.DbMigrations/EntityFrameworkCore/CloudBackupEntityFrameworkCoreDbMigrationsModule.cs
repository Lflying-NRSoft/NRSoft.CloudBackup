using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace NRSoft.CloudBackup.EntityFrameworkCore
{
    [DependsOn(
        typeof(CloudBackupEntityFrameworkCoreModule)
        )]
    public class CloudBackupEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<CloudBackupMigrationsDbContext>();
        }
    }
}
