﻿using System;
using AutoMapper;
using VacationHireInc.Domain.DataTransferObjects;
using VacationHireInc.Domain.Entities;

namespace VacationHireInc.Service
{
	public class MappingProfile : Profile
    {
		public MappingProfile()
		{
            CreateMap<Order, OrderDto>();
            CreateMap<OrderForCreationDto, Order>();

            CreateMap<RentableProduct, IRentableProductDto>().As<RentableProductDto>();
            CreateMap<RentableProduct, RentableProductDto>();

            CreateMap<ProductReturnalInfo, ProductReturnalInfoDto>()
                .Include<VechicleReturnalInfo, VechicleReturnalInfoDto>();
            CreateMap<VechicleReturnalInfo, VechicleReturnalInfoDto>();
            CreateMap<VechicleReturnalInfoCreationDto, VechicleReturnalInfo>();
        }
	}
}

