using System;
using AutoMapper;
using VacationHireInc.DataAccess.Repositories;
using VacationHireInc.DataAccess.Repositories.Interfaces;
using VacationHireInc.Domain.DataTransferObjects;
using VacationHireInc.Domain.Exceptions;
using VacationHireInc.Service.Orders.Interfaces;

namespace VacationHireInc.Service.Orders
{
	public class GetOrderStrategy : IGetOrderStrategy
    {
        private readonly IOrdersRepository ordersRepository;
        private readonly IMapper mapper;

        public GetOrderStrategy(
            IOrdersRepository ordersRepository,
            IMapper mapper)
		{
            this.ordersRepository = ordersRepository;
            this.mapper = mapper;
        }

        public async Task<OrderDto> GetOrder(Guid id)
        {
            var folder = await ordersRepository.GetOrderById(id);
            if (folder is null)
            {
                throw new NotFoundException("Order", id);
            }
            return mapper.Map<OrderDto>(folder);
        }
    }
}

