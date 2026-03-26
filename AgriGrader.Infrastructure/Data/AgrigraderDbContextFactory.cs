using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;


namespace AgriGrader.Infrastructure.Data
{
    public class AgrigraderDbContextFactory : IDesignTimeDbContextFactory<AgrigraderDbContext>
    {
        public AgrigraderDbContext CreateDbContext(string[] args)
        {
            // Read config from appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // points to API project
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<AgrigraderDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

         

            return new AgrigraderDbContext(optionsBuilder.Options);
        }

       
    }
}
