using AspnetCore.EFCore_Dapper.Data.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace AspnetCore.EFCore_Dapper.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            var host = WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();

            DbInitializer.Initialize();
            return host;
        }
    }
}
