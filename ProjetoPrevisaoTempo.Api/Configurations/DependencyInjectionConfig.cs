using ProjetoPrevisaoTempo.Infra.CrossCutting.IoC;
using System.Diagnostics.CodeAnalysis;

namespace ProjetoPrevisaoTempo.Api.Configurations
{
    [ExcludeFromCodeCoverage]
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}
