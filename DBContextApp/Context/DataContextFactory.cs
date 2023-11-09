using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DBContextApp.Context
{
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        private static string? _connectionString;

        public DataContext CreateDbContext()
        {
            return CreateDbContext(null);
        }

        public DataContext CreateDbContext(string[] args)
        {
            if (string.IsNullOrEmpty(_connectionString))
            {
                LoadConnectionString();
            }

            var builder = new DbContextOptionsBuilder<DataContext>();
            builder.UseNpgsql(_connectionString);

            return new DataContext(builder.Options);
        }

        private static void LoadConnectionString()
        {
            var builder = new ConfigurationBuilder();
            builder
                .AddJsonFile("appsettings.json", optional: false)
                .AddUserSecrets<DataContextFactory>();

            var configuration = builder.Build();

            _connectionString = configuration.GetConnectionString("WebApiDatabase");
        }
    }
}
