using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace NRSoft.CloudBackup.ConfigBackups
{
    public class ConfigBackupAppService : CloudBackupAppService, IConfigBackupAppService
    {
        private readonly IRepository<ConfigBackup, Guid> _configBackupRepository;

        public ConfigBackupAppService(IRepository<ConfigBackup, Guid> configBackupRepository)
        {
            _configBackupRepository = configBackupRepository;
        }

        public async Task<ConfigBackupDto> CreateAsync(string text)
        {
            var backup = await _configBackupRepository.InsertAsync(
                new ConfigBackup { Content = text }
            );

            return new ConfigBackupDto
            {
                Content = backup.Content
            };
        }

        public async Task DeleteAsync(Guid id)
        {
            await _configBackupRepository.DeleteAsync(id);
        }

        public async Task<List<ConfigBackupDto>> GetListAsync()
        {
            var items = await _configBackupRepository.GetListAsync();
            return items
                .Select(item => new ConfigBackupDto
                {
                    Code = item.Code,
                    Name = item.Name,
                    Content = item.Content
                }).ToList();
        }
    }
}