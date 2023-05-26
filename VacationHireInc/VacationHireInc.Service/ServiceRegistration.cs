using System;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using VacationHireInc.Domain.DataTransferObjects;
using VacationHireInc.Service.Orders;
using VacationHireInc.Service.Orders.Interfaces;
using VacationHireInc.Service.Orders.Validators;

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

            // Register Validators
            services.AddTransient<IValidator<OrderForCreationDto>, OrderCreationValidator>();

            return services;
        }
    }
}

