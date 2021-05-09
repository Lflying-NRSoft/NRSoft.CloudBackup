using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace NRSoft.CloudBackup.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */
    public class CloudBackupMigrationsDbContextFactory : IDesignTimeDbContextFactory<CloudBackupMigrationsDbContext>
    {
        public CloudBackupMigrationsDbContext CreateDbContext(string[] args)
        {
            CloudBackupEfCoreEntityExtensionMappings.Configure();

            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<CloudBackupMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Default"));

            return new CloudBackupMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../NRSoft.CloudBackup.DbMigrator/"))
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
