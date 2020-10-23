using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
namespace Factory.Models
{
  public class DesignTimeDbContextTreat
  {
    public class TreatContextTreat : IDesignTimeDbContextTreat<TreatContext>
    {

      TreatContext IDesignTimeDbContextTreat<TreatContext>.CreateDbContext(string[] args)
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