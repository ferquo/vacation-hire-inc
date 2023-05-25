using System;
using VacationHireInc.Domain.DataTransferObjects;

namespace VacationHireInc.Service.Orders.Interfaces
{
	public interface IGetOrdersStrategy
	{
        Task<PaginatedResponse<OrderDto>> GetOrders(FilterRequest filter);
    }
}

