using System;
using IAEGoogleDrie.Configuration;
using Microsoft.EntityFrameworkCore;

namespace IAEGoogleDrie.Storage.EntityFrameworkCore.Configuration
{
    public interface IEfCoreConfiguration : IConfigurator
    {
        void AddDbContext<TDbContext>(Action<DbContextConfiguration<TDbContext>> action)
            where TDbContext : DbContext;
    }
}