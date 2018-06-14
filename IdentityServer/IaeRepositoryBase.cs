using IAEGoogleDrie.Data.Uow;
using IAEGoogleDrie.Domain.Entities;
using IAEGoogleDrie.Storage.EntityFrameworkCore;
using IAEGoogleDrie.Storage.EntityFrameworkCore.Repositories;

namespace IdentityServer
{
    public class IaeRepositoryBase<TEntity, TPrimaryKey> : EfCoreRepositoryBase<IaeContext, TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>
    {
        public IaeRepositoryBase(IDbContextProvider<IaeContext> dbContextProvider, IUnitOfWorkManager unitOfWorkManager)
            : base(dbContextProvider, unitOfWorkManager)
        {
        }
    }

    /// <summary>
    /// Base class for custom repositories of the application.
    /// This is a shortcut of <see cref="DemoRepositoryBase{TEntity,TPrimaryKey}"/> for <see cref="int"/> primary key.
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    public abstract class DemoRepositoryBase<TEntity> : IaeRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected DemoRepositoryBase(IDbContextProvider<IaeContext> dbContextProvider, IUnitOfWorkManager unitOfWorkManager)
            : base(dbContextProvider, unitOfWorkManager)
        {
        }
    }
}
