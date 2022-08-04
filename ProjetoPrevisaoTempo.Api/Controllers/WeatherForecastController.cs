using Bogus;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using ProjetoPrevisaoTempo.Application.Interfaces;
using ProjetoPrevisaoTempo.Application.Services;
using ProjetoPrevisaoTempo.Domain.Cidades;
using ProjetoPrevisaoTempo.Domain.Temperaturas;
using ProjetoPrevisaoTempo.Domain.Temperatures;
using ServiceStack.Text;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ProjetoPrevisaoTempo.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherService _weatherService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherService weatherService)
        {
            _logger = logger;
            _weatherService = weatherService;
        }

        [HttpGet("GetCityesTempToday/{type}/{total}")]
        public async Task<IActionResult> GetCityesTempToday([FromRoute][Required] string type, int total = 3)
        {
            if (string.IsNullOrEmpty(type) || !Enum.TryParse(type, out TypeTempEnum tempEnum))
                return BadRequest();

            var result = await _weatherService.GetCityesTempToday(tempEnum, total);

            if(result.Any())
                return Ok(result);

            return NotFound();
        }


        [HttpPut(Name = "PopulateDatabaseFakeData")]
        [ExcludeFromCodeCoverage]
        public IActionResult PopulateDatabaseFakeData()
        {
            var fakeCity = new Faker<City>();
            fakeCity.RuleFor(s => s.Name, f => f.Address.City());
            fakeCity.RuleFor(s => s.Country, f => f.Address.Country());
            fakeCity.RuleFor(s => s.Population, f => f.Random.Double());


            var fakeData = new Faker<Weather>();
            fakeData.RuleFor(s => s.Date, f=> f.Date.Future());
            fakeData.RuleFor(s => s.Cnt, CntEnum.Grau);
            fakeData.RuleFor(s => s.Min, f => f.Random.Number(10));
            fakeData.RuleFor(s => s.Max, f => f.Random.Number(10));
            fakeData.RuleFor(s => s.City, f => fakeCity.Generate());
            fakeData.RuleFor(s => s.Humidity, f => f.Random.Double());


            var result = _weatherService.Create(fakeData.Generate(50));

            return Ok();
        }
    }
}