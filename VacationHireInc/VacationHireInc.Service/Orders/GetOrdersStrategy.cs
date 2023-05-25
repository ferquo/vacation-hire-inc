using System;
using AutoMapper;
using VacationHireInc.DataAccess.Repositories.Interfaces;
using VacationHireInc.Domain.DataTransferObjects;
using VacationHireInc.Service.Orders.Interfaces;

namespace VacationHireInc.Service.Orders
{
	public class GetOrdersStrategy: IGetOrdersStrategy
    {
        private readonly IOrdersRepository ordersRepository;
        private readonly IMapper mapper;

        public GetOrdersStrategy(
            IOrdersRepository ordersRepository,
            IMapper mapper)
        {
            this.ordersRepository = ordersRepository;
            this.mapper = mapper;
        }

        public async Task<PaginatedResponse<OrderDto>> GetOrders(FilterRequest filter)
        {
            filter = filter ?? new FilterRequest();
            var skip = (filter.Page - 1) * filter.PageSize;
            var resultedItems = await ordersRepository.GetOrdersFiltered(skip, filter.PageSize);
            var total = await ordersRepository.GetTotalMatchingFilter();

            return new PaginatedResponse<OrderDto>
            {
                Page = filter.Page,
                PageSize = resultedItems.Count(),
                TotalItemCount = total,
                Results = mapper.Map<List<OrderDto>>(resultedItems),
            };
        }
    }
}

