using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NRSoft.CloudBackup.ConfigBackups
{
    public class CreateUpdateConfigBackupDto
    {
        /// <summary>
        /// 配置文件备份的标识
        /// </summary>
        [Required]
        [StringLength(128)]
        public string Code { get; set; }

        /// <summary>
        /// 配置文件备份的名称
        /// </summary>
        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        /// <summary>
        /// 配置文件备份的内容
        /// </summary>
        [Required]
        public string Content { get; set; }
    }
}
