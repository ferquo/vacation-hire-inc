using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using FluentAssertions;
using Moq;
using VacationHireInc.DataAccess.Repositories.Interfaces;
using VacationHireInc.Domain.DataTransferObjects;
using VacationHireInc.Service.Orders;
using VacationHireInc.Service.Orders.Validators;

namespace VacationHireInc.Service.Tests
{
	public class CreateOrderStrategyTests
	{
        [Theory]
        [InlineData("")]
        [InlineData("1")]
        [InlineData("22")]
        public async Task CreatingOrderWithInvalidCustomerNAmeWillThrowExcpetion(string customerName)
        {
            // arrange
            var order = new OrderForCreationDto
            {
                CustomerName = customerName
            };
            var config = new MapperConfiguration(c => {
                c.AddProfile<MappingProfile>();
            });
            var mapper = config.CreateMapper();
            var repository = new Mock<IOrdersRepository>();
            var validator = new OrderCreationValidator(new Mock<IRentableProductRepository>().Object);

            var subject = new CreateOrderStrategy(repository.Object, validator, mapper);

            // act
            Func<Task> act = () => subject.CreateOrder(order);

            // assert
            await act.Should().ThrowAsync<FluentValidation.ValidationException>();
        }
    }
}

