using InfoJobs.API;
using InfoJobs.Migrations;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = CreateHostBuilder(args).Build();

        using var scope = builder.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<InfoJobsDbContext>();
        if (db.Database.GetPendingMigrations().Any())
        {
            db.Database.Migrate();
        }

        builder.Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}