using System;
using FluentValidation;
using VacationHireInc.DataAccess.Repositories;
using VacationHireInc.DataAccess.Repositories.Interfaces;
using VacationHireInc.Domain.DataTransferObjects;

namespace VacationHireInc.Service.Orders.Validators
{
	public class OrderCreationValidator : AbstractValidator<OrderForCreationDto>
    {
        private readonly IRentableProductRepository rentableProductRepository;

        public OrderCreationValidator(
            IRentableProductRepository rentableProductRepository)
		{
            RuleFor(order => order.CustomerName)
                .NotEmpty().WithMessage("Customer Name not specified")
                .MinimumLength(3).WithMessage("Customer Name length must be at least 3 characters")
                .MaximumLength(30).WithMessage("Customer Name length must be at most 30 characters");

            RuleFor(order => order.RentedProductId)
                .MustAsync(ProductExist).WithMessage("The specified product does not exist")
                .NotEmpty().WithMessage("Rented product not specified");

            RuleFor(order => order.ReservedFrom)
                .NotNull().WithMessage("The start date of the reservation not specified")
                .GreaterThanOrEqualTo(DateTime.Today).WithMessage("The start date of the reservation must be in the future");

            RuleFor(order => order.ReservedUntil)
                .NotNull().WithMessage("The end date of the reservation not specified")
                .GreaterThan(order => order.ReservedFrom).WithMessage("The end date of the reservation must be after the start");
            this.rentableProductRepository = rentableProductRepository;
        }

        private async Task<bool> ProductExist(Guid rentedProductId, CancellationToken token)
        {
            return await rentableProductRepository.Exists(rentedProductId);
        }
    }
}

