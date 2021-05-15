using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.DependencyInjection;

namespace NRSoft.CloudBackup
{
    /// <summary>
    /// 启动后执行任务的参数
    /// </summary>
    [BackgroundJobName("CloudBackup:App:Started")]
    public class StartedArgs
    {
    }

    public class StartedJob : AsyncBackgroundJob<StartedArgs>, ITransientDependency
    {
        public override Task ExecuteAsync(StartedArgs args)
        {
            Logger.LogDebug("延时3秒的任务正在被执行");
            return Task.CompletedTask;
        }
    }
}
