using System;
using FluentValidation;
using VacationHireInc.Domain.DataTransferObjects;

namespace VacationHireInc.Service.Orders.Validators
{
	public class OrderCreationValidator : AbstractValidator<OrderForCreationDto>
    {
		public OrderCreationValidator()
		{
            RuleFor(order => order.CustomerName)
                .NotEmpty().WithMessage("Customer Name not specified")
                .MinimumLength(3).WithMessage("Customer Name length must be at least 3 characters")
                .MaximumLength(30).WithMessage("Customer Name length must be at most 30 characters");

            RuleFor(order => order.PaidAmount)
                .GreaterThan(0).WithMessage("The amount paid must be a positive number");

            // Can be improved by checking the db for it's existence
            RuleFor(order => order.RentedProductId)
                .NotEmpty().WithMessage("Rented product not specified");

            // Can be improved by looking up the currency from the currencylayer API
            RuleFor(order => order.PaidInCurrency)
                .NotEmpty().WithMessage("Currency not specified");

            RuleFor(order => order.ReservedFrom)
                .NotNull().WithMessage("The start date of the reservation not specified")
                .GreaterThanOrEqualTo(DateTime.Today).WithMessage("The start date of the reservation must be in the future");

            RuleFor(order => order.ReservedUntil)
                .NotNull().WithMessage("The end date of the reservation not specified")
                .GreaterThan(order => order.ReservedFrom).WithMessage("The end date of the reservation must be after the start");

        }
	}
}

