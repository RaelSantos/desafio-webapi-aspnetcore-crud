using Microsoft.Extensions.Options;
using PasqualiBackend.Business.interfaces;
using PasqualiBackend.Business.Notificacoes;
using PasqualiBackend.Business.Services;
using PasqualiBackend.Data.Context;
using PasqualiBackend.Data.Repository;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace PasqualiBackend.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MeuDbContext>();
         
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            services.AddScoped<INotificador, Notificador>();          
            services.AddScoped<IUsuarioService, UsuarioService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}
