using System;
using System.ComponentModel.DataAnnotations;

namespace NRSoft.CloudBackup.ConfigBackups
{
    public class ConfigBackupDto
    {
        [Key]
        [Display(Name = "主键")]
        //[AutoGenerateColumn(Ignore = true)]
        public Guid Id { get; set; }

        /// <summary>
        /// 配置文件备份的标识
        /// </summary>
        [Display(Name = "标识")]
        public string Code { get; set; }

        /// <summary>
        /// 配置文件备份的名称
        /// </summary>
        [Display(Name = "名称")]
        public string Name { get; set; }

        /// <summary>
        /// 配置文件备份的内容
        /// </summary>
        [Display(Name = "内容")]
        public string Content { get; set; }
    }
}
