using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace NRSoft.CloudBackup.ConfigBackups
{
    public interface IConfigBackupAppService : IApplicationService
    {
        Task<List<ConfigBackupDto>> GetListAsync();
        Task<ConfigBackupDto> CreateAsync(CreateUpdateConfigBackupDto input);
        Task DeleteAsync(Guid id);
    }
}