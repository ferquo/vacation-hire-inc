using System;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using VacationHireInc.DataAccess.Repositories;
using VacationHireInc.DataAccess.Repositories.Interfaces;
using VacationHireInc.Domain.DataTransferObjects;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class VacationHireIncServiceCollectionExtensions
    {
        public static IServiceCollection AddConfig(
             this IServiceCollection services, IConfiguration config)
        {
            return services;
        }

        public static IServiceCollection AddVacationHireIncDataAccessDependencies(
             this IServiceCollection services)
        {
            // Register repositories
            services.AddScoped<IOrdersRepository, OrdersRepository>();
            services.AddScoped<IRentableProductRepository, RentableProductRepository>();
            services.AddScoped<IVechicleReturnalInfoRepository, VechicleReturnalInfoRepository>();

            return services;
        }
    }
}

