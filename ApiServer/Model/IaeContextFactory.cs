using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ApiServer.Model
{
    public class IaeContextFactory : IDesignTimeDbContextFactory<IaeContext>
    {
        public IaeContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<IaeContext>();

            builder.UseSqlServer("server=localhost;Database=Vds;User ID=sa;Password=Echo@1927;Integrated Security=false;MultipleActiveResultSets=true");
            return new IaeContext(builder.Options, null, null);
        }
    }
}