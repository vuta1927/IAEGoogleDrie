using Microsoft.EntityFrameworkCore;

namespace IAEGoogleDrie.Storage.EntityFrameworkCore.Repositories
{
    public interface IRepositoryWithDbContext
    {
        DbContext GetDbContext();
    }
}