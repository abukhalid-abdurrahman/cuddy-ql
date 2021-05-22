using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace FamilyBusiness.Database
{
    public class FamilyContextFactory : IDesignTimeDbContextFactory<FamilyContext>
    {
        public FamilyContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<FamilyContext>();
            builder.UseSqlite(configuration.GetConnectionString("FamilyDb"));
            return new FamilyContext(builder.Options);
        }
    }
}