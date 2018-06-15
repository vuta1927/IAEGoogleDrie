using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace IdentityServer
{
    public class IaeContextFactory : IDesignTimeDbContextFactory<IaeContext>
    {
        public IaeContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<IaeContext>();

            builder.UseSqlServer("server=localhost;Database=IAE.Drive;User ID=sa;Password=Echo@1927;Integrated Security=false;MultipleActiveResultSets=true");
            return new IaeContext(builder.Options, null, null);
        }
    }
}