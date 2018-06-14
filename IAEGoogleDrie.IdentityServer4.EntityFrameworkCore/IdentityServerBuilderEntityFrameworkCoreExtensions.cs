using IdentityServer4.Stores;
using Microsoft.Extensions.DependencyInjection;

namespace IAEGoogleDrie.IdentityServer4.EntityFrameworkCore
{
    public static class IdentityServerBuilderEntityFrameworkCoreExtensions
    {
        public static IIdentityServerBuilder AddAppPersistedGrants<TDbContext>(this IIdentityServerBuilder builder)
            where TDbContext : IPersistedGrantDbContext
        {
            builder.Services.AddTransient<IPersistedGrantStore, PersistentGrantStore>();
            return builder;
        }
    }
}