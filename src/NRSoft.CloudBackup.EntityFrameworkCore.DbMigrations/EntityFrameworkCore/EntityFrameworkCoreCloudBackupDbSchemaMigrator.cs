using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NRSoft.CloudBackup.Data;
using Volo.Abp.DependencyInjection;

namespace NRSoft.CloudBackup.EntityFrameworkCore
{
    public class EntityFrameworkCoreCloudBackupDbSchemaMigrator
        : ICloudBackupDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreCloudBackupDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the CloudBackupMigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<CloudBackupMigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}