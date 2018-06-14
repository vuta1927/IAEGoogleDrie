using IAEGoogleDrie.Data.Repositories;
using IAEGoogleDrie.Data.Uow;
using IAEGoogleDrie.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IAEGoogleDrie.Storage.EntityFrameworkCore.Repositories
{
    public class EfCoreRepositoryBase<TDbContext, TEntity> : EfCoreRepositoryBase<TDbContext, TEntity, int>, IRepository<TEntity>
        where TEntity : class, IEntity<int>
        where TDbContext : DbContext
    {
        public EfCoreRepositoryBase(IDbContextProvider<TDbContext> dbContextProvider, IUnitOfWorkManager unitOfWorkManager) 
            : base(dbContextProvider, unitOfWorkManager)
        {
        }
    }
}