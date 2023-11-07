using DBContextApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DBContextApp.Context
{
    public class DataContext : DbContext
    {
        public DbSet<Pet> Pets { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Breed> Breeds { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Owner> Owners { get; set; }

        public DbSet<Collar> Collars { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    }
}