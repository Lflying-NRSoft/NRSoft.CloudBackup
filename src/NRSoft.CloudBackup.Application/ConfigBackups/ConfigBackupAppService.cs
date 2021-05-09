using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
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

        public async Task<ConfigBackupDto> CreateAsync(CreateUpdateConfigBackupDto input)
        {
            //await CheckCreatePolicyAsync();
            var entity = ObjectMapper.Map<CreateUpdateConfigBackupDto, ConfigBackup>(input);
            if (entity is IEntity<Guid> entityWithGuidId && entityWithGuidId.Id == Guid.Empty)
            {
                EntityHelper.TrySetId(
                    entityWithGuidId,
                    () => GuidGenerator.Create(),
                    true
                );
            }

            await _configBackupRepository.InsertAsync(entity, autoSave: true);

            return ObjectMapper.Map<ConfigBackup, ConfigBackupDto>(entity);
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
                    Id = item.Id,
                    Code = item.Code,
                    Name = item.Name,
                    Content = item.Content
                }).ToList();
        }
    }
}