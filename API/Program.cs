using Infrastructure.data;
using Microsoft.EntityFrameworkCore;

namespace API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var Services = scope.ServiceProvider;
                var loggerFactory = Services.GetRequiredService<ILoggerFactory>();
                try 
                {
                     var context = Services.GetRequiredService<StoreContext>();
                     await context.Database.MigrateAsync();
                     await StoreContextSeed.SeedAsync(context, loggerFactory);
                }
                catch (Exception ex )
                {
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(ex, "an error occured during migration");
                }

            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
