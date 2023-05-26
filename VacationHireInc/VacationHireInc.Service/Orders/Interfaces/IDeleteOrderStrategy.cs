using System;
namespace VacationHireInc.Service.Orders.Interfaces
{
	public interface IDeleteOrderStrategy
	{
		Task Delete(Guid id);
	}
}

