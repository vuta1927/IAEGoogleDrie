using Microsoft.EntityFrameworkCore;

namespace IAEGoogleDrie.Storage.EntityFrameworkCore
{
    public interface IDbContextProvider<out TDbContext>
        where TDbContext : DbContext
    {
        TDbContext GetDbContext();
    }
}