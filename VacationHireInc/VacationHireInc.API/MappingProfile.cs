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
        }
	}
}

