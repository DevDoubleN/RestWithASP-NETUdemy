using Domain.Entities.Models.Person;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Infrastructure.Core.Context
{
    public class DataContext : DbContext
    {
        #region Constructor
        public DataContext() : base()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        #endregion

        #region DbSet's
        public DbSet<Person> Person { get; set; }
        #endregion

        #region Members of DataContext
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .AddJsonFile(Directory.GetCurrentDirectory())
                   .Build();

                string config = configuration.GetConnectionString("Connection");

                optionsBuilder.UseMySql(config, ServerVersion.AutoDetect(config));
            }
        }
        #endregion
    }
}
