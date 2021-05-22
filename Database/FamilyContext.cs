using FamilyBusiness.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace FamilyBusiness.Database
{
    public sealed class FamilyContext : DbContext
    {
        public FamilyContext(DbContextOptions<FamilyContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Family> Families { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}