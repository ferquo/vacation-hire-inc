using System;
using VacationHireInc.Domain.DataTransferObjects;

namespace VacationHireInc.Service.RentableProducts.Interfaces
{
    public interface IGetRentableProductsStrategy
	{
        Task<IEnumerable<RentableProductDto>> GetAllRentableProducts();
    }
}

