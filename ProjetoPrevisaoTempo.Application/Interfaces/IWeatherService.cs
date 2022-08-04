using ProjetoPrevisaoTempo.Application.Services;
using ProjetoPrevisaoTempo.Domain.Temperaturas;

namespace ProjetoPrevisaoTempo.Application.Interfaces
{
    public interface IWeatherService
    {
        Task<Weather> GetCityesTempToday(TypeTempEnum type);

        Task<bool> Create(List<Weather> data);
        Task<bool> Create(Weather data);
    }
}
