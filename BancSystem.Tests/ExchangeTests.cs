using BancSystem.Currencies;
using BancSystem.Service;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BancSystem.Tests
{
    public class ExchangeTests
    {
        [Fact]
        public void Exchange_100_Rub_In_Euro_1Point18()
        {
            //Arrange
            Exchange exchange = new Exchange();
            CurrencyType firstCurrency = new Ruble();
            CurrencyType secondCurrency = new Euro();

            //Act
            var result = exchange.ConverterCurrency<CurrencyType>(100, firstCurrency, secondCurrency);

            //Assert
            Assert.Equal(1.18, Math.Round(result, 2));
            Assert.NotEqual(1, result);
        }
    }
}
