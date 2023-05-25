using VacationHireInc.Domain.DataTransferObjects;

namespace VacationHireInc.Service.Orders.Interfaces
{
    public interface ICreateOrderStrategy
	{
        Task<OrderDto> CreateOrder(OrderForCreationDto order);
    }
}

