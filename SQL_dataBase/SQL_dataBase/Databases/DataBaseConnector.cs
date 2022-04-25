using Microsoft.EntityFrameworkCore;
using SQL_dataBase.Configuration;
using SQL_dataBase.Models;

namespace SQL_dataBase.Databases
{
    public class DataBaseConnector : DbContext
    {
        public DbSet<Customer>? Customers { get; set; }

        public DataBaseConnector()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString =
                $"Host={Configurator.DbSettings.Server};" +
                $"Port={Configurator.DbSettings.Port};" +
                $"Database={Configurator.DbSettings.Schema};" +
                $"User Id={Configurator.DbSettings.Username};" +
                $"Password={Configurator.DbSettings.Password};";

            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}