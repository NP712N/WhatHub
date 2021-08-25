using _1.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Portal.Infrastructure.EF
{
    public class ApplicationDbContextDesignFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var connectionString = EnvironmentHelper.GetByKey("ConnectionString");
            if (string.IsNullOrEmpty(connectionString))
                connectionString = @"Server=127.0.0.1,5100;Database=what-hub-db;User Id=sa;password=Pass@word;Pooling=False";

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer(connectionString);

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}