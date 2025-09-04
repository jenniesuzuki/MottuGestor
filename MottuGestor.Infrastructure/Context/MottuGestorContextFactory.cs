using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace MottuGestor.Infrastructure.Context;

public class MottuGestorContextFactory : IDesignTimeDbContextFactory<MottuGestorContext>
{
    public MottuGestorContext CreateDbContext(string[] args)
    {
        var basePath = Directory.GetCurrentDirectory();

        var configuration = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json", optional: true)
            .AddJsonFile(Path.Combine("..", "MottuGestor.API", "appsettings.json"), optional: true) // ajuste o caminho se seu API tiver outro nome
            .AddEnvironmentVariables()
            .Build();

        var cs = configuration.GetConnectionString("Default")
                 ?? "User Id=YOUR_USER;Password=YOUR_PASSWORD;Data Source=localhost:1521/XEPDB1";

        var options = new DbContextOptionsBuilder<MottuGestorContext>()
            .UseOracle(cs)
            .Options;

        return new MottuGestorContext(options);
    }
}