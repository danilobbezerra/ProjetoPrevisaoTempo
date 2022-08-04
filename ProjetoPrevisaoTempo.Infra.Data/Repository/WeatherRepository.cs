using ProjetoPrevisaoTempo.Domain.Temperaturas;
using ProjetoPrevisaoTempo.Infra.Data.Contexts;
using System.Diagnostics.CodeAnalysis;

namespace ProjetoPrevisaoTempo.Infra.Data.Repository
{
    [ExcludeFromCodeCoverage]
    public class WeatherRepository : BaseRepository<Weather>, IWeatherRepository
    {
        public WeatherRepository(IMongoContext context) : base(context)
        {
        }
    }
}
