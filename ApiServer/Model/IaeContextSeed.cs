using System;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using IAEGoogleDrie.Security;
using IAEGoogleDrie.Storage.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Polly;

namespace ApiServer.Model
{
    public class IaeContextSeed : IDbContextSeed
    {
        private readonly ILogger<IaeContext> _logger;
        private readonly IaeContext _ctx;
        public IaeContextSeed(ILogger<IaeContext> logger, IaeContext context)
        {
            _logger = logger;
            _ctx = context;
        }
        public Type ContextType => typeof(IaeContext);
        public async Task SeedAsync()
        {
            var policy = CreatePolicy(nameof(IaeContext));

            await policy.ExecuteAsync(async () =>
            {
                using (_ctx)
                {
                    await AddUser(_ctx);
                }
            });
        }

        private async Task AddUser(IaeContext _ctx)
        {
            _ctx.Database.Migrate();


            if (!_ctx.Users.Any(x => x.Email == "admin@demo.com"))
            {
                // Add 'administrator' role
                var adminRole = await _ctx.Roles.FirstOrDefaultAsync(r => r.RoleName == "Administrator");
                if (adminRole == null)
                {
                    adminRole = new Role
                    {
                        RoleName = "Administrator",
                        NormalizedRoleName = "ADMINISTRATOR"
                    };
                    _ctx.Roles.Add(adminRole);
                    await _ctx.SaveChangesAsync();
                }

                // Create admin user
                var adminUser = _ctx.Users.FirstOrDefault(u => u.UserName == "admin");
                if (adminUser == null)
                {
                    adminUser = new User
                    {
                        UserName = "admin",
                        NormalizedUserName = "ADMIN",
                        Name = "admin",
                        Surname = "admin",
                        Email = "admin@demo.com",
                        NormalizedEmail = "ADMIN@DEMO.COM",
                        IsActive = true,
                        EmailConfirmed = true,
                        PasswordHash = "AQAAAAEAACcQAAAAEJtgQFVsPu2OwWrq0EmFohzSY1uzvWD474ucMUmwLek5A8iXuWpjIl061y4C2z5Fow==" //vdsFuturisx@2018
                    };

                    _ctx.Users.Add(adminUser);

                    _ctx.SaveChanges();

                    _ctx.UserRoles.AddRange(
                        new UserRole(adminUser.Id, adminRole.Id));

                    _ctx.SaveChanges();
                }
            }

        }
        

        private Policy CreatePolicy(string prefix, int retries = 3)
        {
            return Policy.Handle<SqlException>()
                .WaitAndRetryAsync(
                    retryCount: retries,
                    sleepDurationProvider: retry => TimeSpan.FromSeconds(5),
                    onRetry: (exception, timeSpan, retry, ctx) =>
                    {
                        _logger.LogTrace($"[{prefix}] Exception {exception.GetType().Name} with message ${exception.Message} detected on attempt {retry} of {retries}");
                    }
                );
        }
    }
}