using System;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using VacationHireInc.Domain.DataTransferObjects;
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

            // Register Validators
            services.AddTransient<IValidator<OrderForCreationDto>, OrderCreationValidator>();
            services.AddTransient<IValidator<VechicleReturnalInfoCreationDto>, VechicleReturnalInfoCreationValidator>();

            return services;
        }
    }
}

