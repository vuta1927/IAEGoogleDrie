using Microsoft.EntityFrameworkCore;

namespace IAEGoogleDrie.Storage.EntityFrameworkCore.Configuration
{
    public interface IDbContextConfigurer<TDbContext>
        where TDbContext : DbContext
    {
        void Configure(DbContextConfiguration<TDbContext> configuration);
    }
}