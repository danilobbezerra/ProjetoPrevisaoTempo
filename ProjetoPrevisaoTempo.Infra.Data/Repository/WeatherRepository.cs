using ProjetoPrevisaoTempo.Infra.Data.Contexts;
using System.Diagnostics.CodeAnalysis;
using ProjetoPrevisaoTempo.Domain.Weathers;

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
