using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IAEGoogleDrie.Data.Uow;
using IAEGoogleDrie.IdentityServer4;
using IAEGoogleDrie.IdentityServer4.EntityFrameworkCore;
using IAEGoogleDrie.Security;
using IAEGoogleDrie.Security.Permissions;
using IAEGoogleDrie.Storage.EntityFrameworkCore;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApiServer.Model
{
    public class IaeContext : DataContextBase<IaeContext>, IPersistedGrantDbContext
    {
        public IaeContext(DbContextOptions<IaeContext> options, ICurrentUnitOfWorkProvider currentUnitOfWorkProvider, IMediator eventBus)
            : base(options, currentUnitOfWorkProvider, eventBus)
        { }

        public DbSet<PersistedGrantEntity> PersistedGrants { get; set; }
        public new DbSet<User> Users { get; set; }
        public DbSet<PermissionRole> PermissionRoles { get; set; }
        public new DbSet<Permission> Permissions { get; set; }
    }
}
