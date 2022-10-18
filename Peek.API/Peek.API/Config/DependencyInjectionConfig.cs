using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Peek.Framework.Common.Utils;
using Peek.Models.Interfaces;
using Peek.Repository;
using Peek.Service;

namespace Peek.API.Config
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddDependencyInjectionConfiguration(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IPeekService, PeekService>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IPeekReaderRepository, PeekReaderRepository>();
            services.AddScoped<IPeekWriterRepository, PeekWriterRepository>();
            services.AddScoped<IUserCommandRepository, UserCommandRepository>();
            services.AddScoped<IUserConsultRepository, UserConsultRepository>();


            services.AddScoped<IHttp, Http>();

            services.AddMemoryCache();

            return services;
        }
    }
}