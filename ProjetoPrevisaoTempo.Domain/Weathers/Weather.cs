using System.Diagnostics.CodeAnalysis;
using MongoDB.Bson;
using ProjetoPrevisaoTempo.Domain.Cities;

namespace ProjetoPrevisaoTempo.Domain.Weathers
{
    [ExcludeFromCodeCoverage]
    public class Weather
    {
        public ObjectId Id { get; private set; }

        public DateTime Date { get; set; }

        public double Min { get; set; }

        public double Max { get; set; }

        public CntEnum Cnt { get; set; }

        public double Humidity { get; set; }

        public City City { get; set; }
    }
}
