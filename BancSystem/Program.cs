using BancSystem.Currencies;
using Newtonsoft.Json;
using BancSystem.Generators;
using BancSystem.Models;
using BancSystem.Service;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using System.Threading;

namespace BancSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Client> clients = new List<Client>();
            Generator generator = new Generator();
            var locker = new object();

            ThreadPool.QueueUserWorkItem(_ =>
            {
                for (int i = 0; i < 100; i++)
                {
                    lock (locker)
                    {
                        clients.AddRange(generator.GetGeneratedListClients(1, i));
                    }
                    Thread.Sleep(2000);
                }

            });


            while (true)
            {
                lock (locker)
                {
                    foreach (var item in clients)
                    {
                        Console.WriteLine(item.PassportID);
                    }
                }
                Thread.Sleep(2000);
            }
        }
    }
}
