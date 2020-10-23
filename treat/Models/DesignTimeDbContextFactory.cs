using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
namespace Treat.Models
{
  public class DesignTimeDbContextTreat
  {
    public class TreatContextTreat : IDesignTimeDbContextFactory<TreatContext>
    {

      TreatContext IDesignTimeDbContextFactory<TreatContext>.CreateDbContext(string[] args)
      {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<TreatContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        builder.UseMySql(connectionString);

        return new TreatContext(builder.Options);
      }
    }
  }
}