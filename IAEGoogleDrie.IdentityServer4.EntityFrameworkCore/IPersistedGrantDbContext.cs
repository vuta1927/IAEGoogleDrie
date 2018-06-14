using Microsoft.EntityFrameworkCore;

namespace IAEGoogleDrie.IdentityServer4.EntityFrameworkCore
{
    public interface IPersistedGrantDbContext
    {
        DbSet<PersistedGrantEntity> PersistedGrants { get; set; }
    }
}
