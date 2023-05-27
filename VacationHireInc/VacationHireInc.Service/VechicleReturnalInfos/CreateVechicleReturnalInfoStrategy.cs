using System;
using AutoMapper;
using FluentValidation;
using VacationHireInc.DataAccess.Repositories;
using VacationHireInc.DataAccess.Repositories.Interfaces;
using VacationHireInc.Domain.DataTransferObjects;
using VacationHireInc.Domain.Entities;
using VacationHireInc.Service.VechicleReturnalInfos.Interfaces;

namespace VacationHireInc.Service.VechicleReturnalInfos
{
	public class CreateVechicleReturnalInfoStrategy : ICreateVechicleReturnalInfoStrategy
    {
        private readonly IVechicleReturnalInfoRepository vechicleReturnalInfoRepository;
        private readonly IValidator<VechicleReturnalInfoCreationDto> vechicleReturnalValidator;
        private readonly IMapper mapper;

        public CreateVechicleReturnalInfoStrategy(
            IVechicleReturnalInfoRepository vechicleReturnalInfoRepository,
            IValidator<VechicleReturnalInfoCreationDto> vechicleReturnalValidator,
            IMapper mapper)
		{
            this.vechicleReturnalInfoRepository = vechicleReturnalInfoRepository;
            this.vechicleReturnalValidator = vechicleReturnalValidator;
            this.mapper = mapper;
        }

        public async Task<VechicleReturnalInfoDto> CreateOrder(VechicleReturnalInfoCreationDto vechicleReturnalInfo)
        {
            await vechicleReturnalValidator.ValidateAndThrowAsync(vechicleReturnalInfo);

            var vechicleReturnalEntity = mapper.Map<VechicleReturnalInfo>(vechicleReturnalInfo);
            await vechicleReturnalInfoRepository.Create(vechicleReturnalEntity);
            return mapper.Map<VechicleReturnalInfoDto>(vechicleReturnalEntity);
        }
    }
}

