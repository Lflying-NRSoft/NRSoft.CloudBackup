using System.Threading.Tasks;

namespace NRSoft.CloudBackup.Data
{
    public interface ICloudBackupDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
