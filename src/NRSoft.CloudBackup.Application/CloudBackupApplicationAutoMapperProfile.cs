using AutoMapper;
using NRSoft.CloudBackup.ConfigBackups;

namespace NRSoft.CloudBackup
{
    public class CloudBackupApplicationAutoMapperProfile : Profile
    {
        public CloudBackupApplicationAutoMapperProfile()
        {
            CreateMap<ConfigBackup, ConfigBackupDto>();
            CreateMap<CreateUpdateConfigBackupDto, ConfigBackup>();
        }
    }
}
