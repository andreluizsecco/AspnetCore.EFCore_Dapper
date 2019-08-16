using AspnetCore.EFCore_Dapper.Data.Repositories.Dapper;
using AspnetCore.EFCore_Dapper.Data.Repositories.EntityFramework;
using AspnetCore.EFCore_Dapper.Domain.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace AspnetCore.EFCore_Dapper.IoC
{
    public static class NativeInjectorConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IAutorEFRepository, AutorEFRepository>();
            services.AddScoped<ILivroEFRepository, LivroEFRepository>();
            services.AddScoped<IAutorDapperRepository, AutorDapperRepository>();
            services.AddScoped<ILivroDapperRepository, LivroDapperRepository>();
        }
    }
}
