using BancSystem.Models;
using BancSystem.Service;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BancSystem.Tests
{
    public class BankServiceTests
    {
        [Fact]
        public void AddAndFindClient()
        {
            //Arrange
            Client client = new Client() 
            { Name = "Василий", Surname = "Бронштейн", Patronymic = "Иорданович", Age = 54, PassportID = 4667 };
            Bank bank = new Bank();

            //Act
            bank.Add<Client>(client);
            var result = bank.FindClient(client);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(client, result);
        }
    }
}
