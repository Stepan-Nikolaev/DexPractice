using BancSystem.Models;
using BancSystem.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace BancSystem.Tests
{
    public class AddMoneyInAccount
    {
        [Fact]
        public void AddMoney()
        {
            //Arrange
            Bank bank = new Bank();
            var locker = new object();
            var someAccaunt = bank.DataBaseClients[0];
            var standart = someAccaunt[0].CountMoney += 200;

            //Act
            ThreadPool.QueueUserWorkItem(_ =>
            {
                lock (locker)
                {
                    someAccaunt[0].CountMoney += 100;
                }
                Thread.Sleep(2000);
            });

            ThreadPool.QueueUserWorkItem(_ =>
            {
                lock (locker)
                {
                    someAccaunt[0].CountMoney += 100;
                }
                Thread.Sleep(2000);
            });

            //Assert
            Assert.Equal(standart, someAccaunt[0].CountMoney);
        }
    }
}
