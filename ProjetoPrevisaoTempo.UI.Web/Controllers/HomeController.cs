using Microsoft.AspNetCore.Mvc;
using ProjetoPrevisaoTempo.UI.Web.Factories;
using ProjetoPrevisaoTempo.UI.Web.Models;
using RestSharp;
using System.Diagnostics;

namespace ProjetoPrevisaoTempo.UI.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IApiModelFactory _apiModelFactory;

        public HomeController(ILogger<HomeController> logger, IApiModelFactory apiModelFactory)
        {
            _logger = logger;
            _apiModelFactory = apiModelFactory;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var client = await _apiModelFactory.GetClientAsync();

            var request = new RestRequest("WeatherForecast/GetCityesTempToday/{type}");
            request.AddUrlSegment("type", "Hot");

            var response = await client.ExecuteGetAsync<WeatherModel>(request);
            if (!response.IsSuccessful)
                throw new HttpRequestException();

            return View(response.Data);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}