using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace AspnetCore.EFCore_Dapper.MVC
{
    public class Program
    {
        public static void Main(string[] args) =>
            CreateWebHostBuilder(args).Build().Run();

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var host = WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
            return host;
        }
    }
}
