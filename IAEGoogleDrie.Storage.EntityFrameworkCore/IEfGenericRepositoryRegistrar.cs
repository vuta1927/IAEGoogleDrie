using System;
using IAEGoogleDrie.Data.Uow;
using Microsoft.Extensions.DependencyInjection;

namespace IAEGoogleDrie.Storage.EntityFrameworkCore
{
    public interface IEfGenericRepositoryRegistrar
    {
        void RegisterForDbContext(Type dbContextType, IServiceCollection services, AutoRepositoryTypesAttribute defaultAutoRepositoryTypesAttribute);
    }
}