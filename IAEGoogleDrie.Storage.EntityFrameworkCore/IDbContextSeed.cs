using System;
using System.Threading.Tasks;
using IAEGoogleDrie.Dependency;

namespace IAEGoogleDrie.Storage.EntityFrameworkCore
{
    public interface IDbContextSeed : ITransientDependency
    {
        Type ContextType { get; }
        Task SeedAsync();
    }
}