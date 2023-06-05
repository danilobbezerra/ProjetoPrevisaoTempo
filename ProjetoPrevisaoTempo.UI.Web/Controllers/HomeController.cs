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
            var client = _apiModelFactory.GetClientAsync();

            var requestHot = new RestRequest("WeatherForecast/GetCityesTempToday/{type}/{total}");
            requestHot.AddUrlSegment("type", "Hot");
            requestHot.AddUrlSegment("total", 3);

            var responseHot = await client.ExecuteGetAsync<List<WeatherModel>>(requestHot);
            if (!responseHot.IsSuccessful)
                throw new HttpRequestException();



            var requestCold = new RestRequest("WeatherForecast/GetCityesTempToday/{type}/{total}");
            requestCold.AddUrlSegment("type", "Cold");
            requestCold.AddUrlSegment("total", 3);

            var responseCold = await client.ExecuteGetAsync<List<WeatherModel>>(requestCold);
            if (!responseCold.IsSuccessful)
                throw new HttpRequestException();

            return View(new HomeModel() 
            { 
                MaxHotToday = responseHot.Data,
                MinHotToday = responseCold.Data
            
            });
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