using MediatR.CommandBus.Abstractions.Application.Mediation.Customers.Commands;
using MediatR.CommandBus.Abstractions.Domain.Repositories;
using MediatR.CommandBus.Console.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;

namespace MediatR.CommandBus.Abstractions.Tests.Composition
{
    public static class CompositionRoot
    {
        private static readonly ServiceCollection ServiceCollection;
        private static readonly IServiceProvider ServiceProvider;

        static CompositionRoot()
        {
            ServiceCollection = new ServiceCollection();

            LoadLogging();
            LoadMediatR();
            LoadBindings();

            ServiceProvider = ServiceCollection.BuildServiceProvider();
        }

        private static void LoadLogging()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.LiterateConsole()
                .Enrich.WithProperty("Application", "MediatR.CommandBus.Abstractions.Tests")
                .CreateLogger();
        }

        private static void LoadMediatR()
        {
            ServiceCollection.AddMediatR(typeof(SetCustomerInactive).Assembly);
        }

        private static void LoadBindings()
        {
            ServiceCollection.AddSingleton<ICustomerCommandRepository, CustomerCommandRepository>();
            ServiceCollection.AddSingleton<ICustomerQueryRepository, CustomerQueryRepository>();
        }

        public static T Get<T>()
        {
            return ServiceProvider.GetService<T>();
        }
    }
}
