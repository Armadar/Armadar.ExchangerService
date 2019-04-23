using Armadar.ExchangerService.Controllers;
using Armadar.ExchangerService.Entities;
using Armadar.ExchangerService.Helpers;
using System;
using Xunit;

namespace Armadar.ExchangerService.Tests
{
    public class ExchangesControllerTest
    {
        ExchangerServiceFake _service;

        public ExchangesControllerTest()
        {            
            _service = new ExchangerServiceFake();  
        }

        [Fact]
        public void GetExchange_ExistingMoneyExchangePassed_ReturnsExchange()
        {
            // Arrange
            string[] money = new string[] { "PEN", "USD" };
            decimal amount = Convert.ToDecimal("100.00");

            // Act
            var info = _service.GetExchange(money[0], money[1]);
            var r = FormatterResponse.getInfoResponse(money[0], money[1], amount, info);

            // Assert
            Assert.IsType<Exchange>(info);
        }

        [Fact]
        public void GetExchange_ExchangeOperationPassed_ReturnsValue()
        {
            // Arrange
            string[] money = new string[] { "PEN", "USD" };
            decimal amount = Convert.ToDecimal("100.00");

            // Act
            var info = _service.GetExchange(money[0], money[1]);
            var r = FormatterResponse.getInfoResponse(money[0], money[1], amount, info);
            decimal value = info.operation == "D" ? amount / info.rate : amount * info.rate;

            // Assert
            Assert.Equal(value,r.value);
        }
    }
}