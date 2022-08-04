using Newtonsoft.Json;
using System;

namespace ProjetoPrevisaoTempo.UI.Web.Models
{
    public class WeatherModel
    {

        public DateTime Date { get; set; }

        public double Min { get; set; }

        public double Max { get; set; }

        public int Cnt { get; set; }

        public double Humidity { get; set; }

        public CityModel City { get; set; }
    }
}
