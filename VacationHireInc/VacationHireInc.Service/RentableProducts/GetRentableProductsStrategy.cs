using System;
using AutoMapper;
using VacationHireInc.DataAccess.Repositories.Interfaces;
using VacationHireInc.Domain.DataTransferObjects;
using VacationHireInc.Service.RentableProducts.Interfaces;

namespace VacationHireInc.Service.RentableProducts
{
	public class GetRentableProductsStrategy : IGetRentableProductsStrategy
    {
        private readonly IRentableProductRepository rentableProductRepository;
        private readonly IMapper mapper;

        public GetRentableProductsStrategy(
            IRentableProductRepository rentableProductRepository,
            IMapper mapper)
		{
            this.rentableProductRepository = rentableProductRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<RentableProductDto>> GetAllRentableProducts()
        {
            var rentableProducts = await rentableProductRepository.GetAllAsync();
            return mapper.Map<List<RentableProductDto>>(rentableProducts);
        }
    }
}

