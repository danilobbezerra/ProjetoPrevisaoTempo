using MongoDB.Bson;
using ProjetoPrevisaoTempo.Application.Interfaces;
using ProjetoPrevisaoTempo.Domain.Temperaturas;
using ProjetoPrevisaoTempo.Infra.Data.Repository;
using ProjetoPrevisaoTempo.Infra.Data.UoW;
using ServiceStack;

namespace ProjetoPrevisaoTempo.Application.Services
{
    public class WeatherService : IWeatherService
    {

        private readonly IWeatherRepository _weatherRepository;
        private readonly IUnitOfWork _uow;

        public WeatherService(IWeatherRepository weatherRepository, IUnitOfWork uow)
        {
            _weatherRepository = weatherRepository;
            _uow = uow;
        }
        public async Task<Weather?> GetCityesTempToday(TypeTempEnum type)
        {
            var result = await _weatherRepository.GetAll();

            return type switch
            {
                TypeTempEnum.Hot => result.OrderByDescending(x => x.Max).FirstNonDefault(),
                TypeTempEnum.Cold => result.OrderBy(x => x.Min).FirstNonDefault(),
                _ => null,
            };
        }

        public async Task<bool> Create(List<Weather> data)
        {
            if(!data.Any())
                return false;

            _weatherRepository.Add(data);
            return await _uow.Commit();
        }

        public async Task<bool> Create(Weather data)
        {
            if (data.Id == ObjectId.Empty)
                return false;

            _weatherRepository.Add(data);
            return await _uow.Commit();

        }

    }
}
