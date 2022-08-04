using ProjetoPrevisaoTempo.Application.Services;
using ProjetoPrevisaoTempo.Domain.Temperaturas;

namespace ProjetoPrevisaoTempo.Application.Interfaces
{
    public interface IWeatherService
    {
        Task<List<Weather>> GetCityesTempToday(TypeTempEnum type, int total);

        Task<bool> Create(List<Weather> data);
        Task<bool> Create(Weather data);
    }
}
