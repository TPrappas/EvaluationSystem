using Bogus;
using Microsoft.EntityFrameworkCore;

namespace EvaluationSystemServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DI.Host = CreateHostBuilder(args).Build();
            
            DI.Host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
    }
}