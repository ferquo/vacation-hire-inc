using System;
using FluentValidation;
using VacationHireInc.DataAccess.Repositories;
using VacationHireInc.DataAccess.Repositories.Interfaces;
using VacationHireInc.Domain.DataTransferObjects;

namespace VacationHireInc.Service.VechicleReturnalInfos.Validators
{
	public class VechicleReturnalInfoCreationValidator : AbstractValidator<VechicleReturnalInfoCreationDto>
    {
        private readonly IOrdersRepository ordersRepository;
        private readonly IVechicleReturnalInfoRepository vechicleReturnalInfoRepository;

        public VechicleReturnalInfoCreationValidator(
            IOrdersRepository ordersRepository,
            IVechicleReturnalInfoRepository vechicleReturnalInfoRepository)
		{
            RuleFor(order => order.OrderId)
                .NotEmpty().WithMessage("Order identifier not specified")
                .MustAsync(OrderExist).WithMessage("The specified order does not exist")
                .MustAsync(ReturnalNotCreatedForOrder).WithMessage("Returnal info already created for order");

            RuleFor(order => order.PaidAmount)
                .GreaterThan(0).WithMessage("The amount paid must be a positive number");

            // Can be improved by looking up the currency from the currencylayer API
            RuleFor(order => order.PaidInCurrency)
                .NotEmpty().WithMessage("Currency not specified");

            // Can be improved by looking up the currency from the currencylayer API
            RuleFor(order => order.FuelPercentage)
                .GreaterThanOrEqualTo(0).WithMessage("Fuel percentage not valid")
                .LessThanOrEqualTo(1).WithMessage("Fuel percentage not valid");
            this.ordersRepository = ordersRepository;
            this.vechicleReturnalInfoRepository = vechicleReturnalInfoRepository;
        }

        private async Task<bool> OrderExist(Guid orderId, CancellationToken token)
        {
            return await ordersRepository.Exists(orderId);
        }

        private async Task<bool> ReturnalNotCreatedForOrder(Guid orderId, CancellationToken token)
        {
            return !await vechicleReturnalInfoRepository.ReturnalExistsForOrder(orderId);
        }
    }
}

