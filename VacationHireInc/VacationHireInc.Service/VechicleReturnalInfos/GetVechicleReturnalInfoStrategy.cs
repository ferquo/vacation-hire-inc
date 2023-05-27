using System;
using AutoMapper;
using VacationHireInc.DataAccess.Repositories;
using VacationHireInc.DataAccess.Repositories.Interfaces;
using VacationHireInc.Domain.DataTransferObjects;
using VacationHireInc.Domain.Exceptions;
using VacationHireInc.Service.VechicleReturnalInfos.Interfaces;

namespace VacationHireInc.Service.VechicleReturnalInfos
{
	public class GetVechicleReturnalInfoStrategy : IGetVechicleReturnalInfoStrategy
    {
        private readonly IVechicleReturnalInfoRepository vechicleReturnalInfoRepository;
        private readonly IMapper mapper;

        public GetVechicleReturnalInfoStrategy(
            IVechicleReturnalInfoRepository vechicleReturnalInfoRepository,
            IMapper mapper)
		{
            this.vechicleReturnalInfoRepository = vechicleReturnalInfoRepository;
            this.mapper = mapper;
        }

        public async Task<VechicleReturnalInfoDto> GetVechicleReturnalInfo(Guid id)
        {
            var vechicleReturnalInfo = await vechicleReturnalInfoRepository.GetById(id);
            if (vechicleReturnalInfo is null)
            {
                throw new NotFoundException("VechicleReturnalInfo", id);
            }
            return mapper.Map<VechicleReturnalInfoDto>(vechicleReturnalInfo);
        }
    }
}

