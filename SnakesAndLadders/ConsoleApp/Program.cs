using Application;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = GetServiceProvider();
        }

        private static ServiceCollection GetServiceProvider()
        {
            var serviceProvider = new ServiceCollection();

            serviceProvider.AddPersistence();

            return serviceProvider;
        }
    }
}