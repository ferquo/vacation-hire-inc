using System;
using VacationHireInc.Domain.DataTransferObjects;

namespace VacationHireInc.Service.Orders.Interfaces
{
	public interface IGetOrderStrategy
	{
		Task<OrderDto> GetOrder(Guid id);
	}
}

