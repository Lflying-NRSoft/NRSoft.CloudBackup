using Microsoft.EntityFrameworkCore;
using NRSoft.CloudBackup.ConfigBackups;
using Volo.Abp;

namespace NRSoft.CloudBackup.EntityFrameworkCore
{
    public static class CloudBackupDbContextModelCreatingExtensions
    {
        public static void ConfigureCloudBackup(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            builder.Entity<ConfigBackup>(b => {
                b.ToTable("ConfigBackup");
            });
        }
    }
}