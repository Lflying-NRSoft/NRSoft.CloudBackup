using System;
using Volo.Abp.Domain.Entities;

namespace NRSoft.CloudBackup.ConfigBackups
{
    public class ConfigBackup : BasicAggregateRoot<Guid>
    {
        /// <summary>
        /// 配置文件备份的标识
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 配置文件备份的名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 配置文件备份的内容
        /// </summary>
        public string Content { get; set; }
    }
}
