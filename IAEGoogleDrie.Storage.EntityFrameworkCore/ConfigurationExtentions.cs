﻿using System;
using System.Reflection;
using IAEGoogleDrie.Configuration;
using IAEGoogleDrie.Data.Uow;
using IAEGoogleDrie.Helpers.Exception;
using IAEGoogleDrie.Reflection;
using IAEGoogleDrie.Storage.EntityFrameworkCore.Configuration;
using IAEGoogleDrie.Storage.EntityFrameworkCore.Repositories;
using IAEGoogleDrie.Storage.EntityFrameworkCore.Uow;
using Microsoft.Extensions.DependencyInjection;

namespace IAEGoogleDrie.Storage.EntityFrameworkCore
{
    public static class ConfigurationExtentions
    {
        public static IConfigure UseEntityFrameworkCore(this IStorageConfiguration configuration, Action<IEfCoreConfiguration> action)
        {
            Throw.IfArgumentNull(action, nameof(action));

            var services = configuration.Configure.Services;
            services.AddSingleton<IEfCoreConfiguration, EfCoreConfiguration>();
            services.AddTransient(typeof(IDbContextProvider<>), typeof(UnitOfWorkDbContextProvider<>));

            var serviceProvider = services.BuildServiceProvider();

            var typefinder = serviceProvider.GetService<ITypeFinder>();
            var dbContextTypes = typefinder.Find(type =>
            {
                var typeInfo = type.GetTypeInfo();
                return typeInfo.IsPublic &&
                       !typeInfo.IsAbstract &&
                       typeInfo.IsClass &&
                       typeof(DataContext).IsAssignableFrom(type);
            });

            foreach (var dbContextType in dbContextTypes)
            {
                serviceProvider.GetService<IEfGenericRepositoryRegistrar>().RegisterForDbContext(dbContextType, services, EfCoreAutoRepositoryTypes.Default);
            }

            //                serviceProvider.GetService<IDbContextTypeMatcher>().Populate(dbContextTypes);

            services.AddSingleton<IDbContextTypeMatcher>(provider =>
            {
                var dbContextTypeMatcher = new DbContextTypeMatcher(provider.GetService<ICurrentUnitOfWorkProvider>());
                dbContextTypeMatcher.Populate(dbContextTypes);
                return dbContextTypeMatcher;
            });
            serviceProvider = services.BuildServiceProvider();
            action.Invoke(serviceProvider.GetService<IEfCoreConfiguration>());
            serviceProvider = services.BuildServiceProvider();
            serviceProvider.GetService<DbContextSeeder>().BeginSeedAsync().Wait();

            return configuration.Configure;
        }
    }
}
