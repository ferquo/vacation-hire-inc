using System;
using AutoMapper;
using VacationHireInc.DataAccess.Repositories;
using VacationHireInc.DataAccess.Repositories.Interfaces;
using VacationHireInc.Domain.Exceptions;
using VacationHireInc.Service.Orders.Interfaces;

namespace VacationHireInc.Service.Orders
{
	public class DeleteOrderStrategy : IDeleteOrderStrategy
    {
        private readonly IOrdersRepository ordersRepository;
        private readonly IMapper mapper;

        public DeleteOrderStrategy(
            IOrdersRepository ordersRepository,
            IMapper mapper)
		{
            this.ordersRepository = ordersRepository;
            this.mapper = mapper;
        }

        public async Task Delete(Guid id)
        {
            if (!await ordersRepository.Exists(id))
            {
                throw new NotFoundException("Order", id);
            }
            await ordersRepository.Delete(id);
        }
    }
}

