using Microsoft.EntityFrameworkCore;
using SubeApi.Models;

namespace SubeApi.DataAccess
{
    public class SubeDbContext:DbContext
    {
        public SubeDbContext(DbContextOptions<SubeDbContext> options):base(options)
        { 
        }

        public DbSet<Sube> Sube { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-6M5B0SOC; Initial Catalog=Subeler; Integrated Security=True; TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
