using DBContextApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DBContextApp.Context
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to postgres with connection string from app settings
            options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
        }

        public DbSet<Pet> Pets { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Breed> Breeds { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}