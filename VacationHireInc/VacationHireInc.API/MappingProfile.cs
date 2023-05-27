using System;
using AutoMapper;
using VacationHireInc.Domain.DataTransferObjects;
using VacationHireInc.Domain.Entities;

namespace VacationHireInc.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
		{
            CreateMap<Order, OrderDto>();
            CreateMap<OrderForCreationDto, Order>();

            CreateMap<RentableProduct, IRentableProductDto>().As<RentableProductDto>();
            CreateMap<RentableProduct, RentableProductDto>();

            CreateMap<VechicleReturnalInfo, VechicleReturnalInfoDto>();
            CreateMap<VechicleReturnalInfoCreationDto, VechicleReturnalInfo>();
        }
	}
}

