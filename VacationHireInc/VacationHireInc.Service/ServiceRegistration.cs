﻿using System;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using VacationHireInc.Domain.DataTransferObjects;
using VacationHireInc.Service;
using VacationHireInc.Service.Currencies;
using VacationHireInc.Service.Currencies.Interfaces;
using VacationHireInc.Service.Orders;
using VacationHireInc.Service.Orders.Interfaces;
using VacationHireInc.Service.Orders.Validators;
using VacationHireInc.Service.RentableProducts;
using VacationHireInc.Service.RentableProducts.Interfaces;
using VacationHireInc.Service.VechicleReturnalInfos;
using VacationHireInc.Service.VechicleReturnalInfos.Interfaces;
using VacationHireInc.Service.VechicleReturnalInfos.Validators;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class VacationHireIncServiceCollectionExtensions
    {
        public static IServiceCollection AddConfig(
             this IServiceCollection services, IConfiguration config)
        {
            return services;
        }

        public static IServiceCollection AddVacationHireIncServiceDependencies(
             this IServiceCollection services)
        {
            // Register Strategies
            services.AddScoped<IGetOrderStrategy, GetOrderStrategy>();
            services.AddScoped<IGetOrdersStrategy, GetOrdersStrategy>();
            services.AddScoped<ICreateOrderStrategy, CreateOrderStrategy>();
            services.AddScoped<IDeleteOrderStrategy, DeleteOrderStrategy>();

            services.AddScoped<IGetRentableProductsStrategy, GetRentableProductsStrategy>();

            services.AddScoped<ICreateVechicleReturnalInfoStrategy, CreateVechicleReturnalInfoStrategy>();
            services.AddScoped<IGetVechicleReturnalInfoStrategy, GetVechicleReturnalInfoStrategy>();

            services.AddScoped<IGetAllCurrenciesStrategy, GetAllCurrenciesStrategy>();
            services.AddScoped<IGeCurrencyExchangeRateToUSDStrategy, GeCurrencyExchangeRateToUSDStrategy>();

            // Register Validators
            services.AddTransient<IValidator<OrderForCreationDto>, OrderCreationValidator>();
            services.AddTransient<IValidator<VechicleReturnalInfoCreationDto>, VechicleReturnalInfoCreationValidator>();

            // Register the mapping profile 
            var config = new MapperConfiguration(c => {
                c.AddProfile<MappingProfile>();
            });
            services.AddSingleton<IMapper>(s => config.CreateMapper());

            return services;
        }
    }
}

