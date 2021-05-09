using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace NRSoft.CloudBackup.Data
{
    /* This is used if database provider does't define
     * ICloudBackupDbSchemaMigrator implementation.
     */
    public class NullCloudBackupDbSchemaMigrator : ICloudBackupDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}