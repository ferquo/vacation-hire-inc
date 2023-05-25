using System;
using AutoMapper;
using FluentValidation;
using VacationHireInc.DataAccess.Repositories;
using VacationHireInc.DataAccess.Repositories.Interfaces;
using VacationHireInc.Domain.DataTransferObjects;
using VacationHireInc.Domain.Entities;
using VacationHireInc.Service.Orders.Interfaces;
using VacationHireInc.Service.Orders.Validators;

namespace VacationHireInc.Service.Orders
{
	public class CreateOrderStrategy : ICreateOrderStrategy
    {
        private readonly IOrdersRepository ordersRepository;
        private readonly IValidator<OrderForCreationDto> orderValidator;
        private readonly IMapper mapper;

        public CreateOrderStrategy(
            IOrdersRepository ordersRepository,
            IValidator<OrderForCreationDto> orderValidator,
            IMapper mapper)
        {
            this.ordersRepository = ordersRepository;
            this.orderValidator = orderValidator;
            this.mapper = mapper;
        }

        public async Task<OrderDto> CreateOrder(OrderForCreationDto order)
        {
            await orderValidator.ValidateAndThrowAsync(order);

            var orderEntity = mapper.Map<Order>(order);
            await ordersRepository.Create(orderEntity);
            return mapper.Map<OrderDto>(orderEntity);
        }
    }
}

