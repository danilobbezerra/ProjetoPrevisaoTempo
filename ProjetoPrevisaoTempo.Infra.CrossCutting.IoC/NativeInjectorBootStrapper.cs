using Microsoft.Extensions.DependencyInjection;
using ProjetoPrevisaoTempo.Application.Interfaces;
using ProjetoPrevisaoTempo.Application.Services;
using ProjetoPrevisaoTempo.Infra.Data.Contexts;
using ProjetoPrevisaoTempo.Infra.Data.Repository;
using ProjetoPrevisaoTempo.Infra.Data.UoW;
using System.Diagnostics.CodeAnalysis;

namespace ProjetoPrevisaoTempo.Infra.CrossCutting.IoC
{
    [ExcludeFromCodeCoverage]
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //// Application
            services.AddTransient<IWeatherService, WeatherService>();


            //services.AddSingleton<IMongoClient, MongoClient>(sp => new MongoClient(configuration.GetConnectionString("MongoDb")));


            //// Infra - Data
            services.AddScoped<IMongoContext, MongoContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IWeatherRepository, WeatherRepository>();
        }
    }
}