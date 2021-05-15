using Microsoft.Extensions.DependencyInjection;
using System;
using Volo.Abp;
using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;
using Volo.Abp.Threading;

namespace NRSoft.CloudBackup
{
    [DependsOn(
        typeof(CloudBackupDomainModule),
        typeof(AbpAccountApplicationModule),
        typeof(CloudBackupApplicationContractsModule),
        typeof(AbpIdentityApplicationModule),
        typeof(AbpPermissionManagementApplicationModule),
        typeof(AbpTenantManagementApplicationModule),
        typeof(AbpFeatureManagementApplicationModule),
        typeof(AbpSettingManagementApplicationModule)
        )]
    public class CloudBackupApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<CloudBackupApplicationModule>();
            });
        }

        public override void OnPostApplicationInitialization(ApplicationInitializationContext context)
        {
            var jobManager = context.ServiceProvider.GetRequiredService<IBackgroundJobManager>();
            AsyncHelper.RunSync(
                async () =>
                {
                    // 初始化操作
                    await jobManager.EnqueueAsync(new StartedArgs(), delay: TimeSpan.FromSeconds(10));

                    // TODO 这里可以增加多个任务
                }
            );
        }
    }
}
