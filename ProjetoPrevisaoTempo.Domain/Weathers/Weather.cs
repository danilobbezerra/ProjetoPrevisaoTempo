using MongoDB.Bson;
using ProjetoPrevisaoTempo.Domain.Cidades;
using ProjetoPrevisaoTempo.Domain.Temperatures;
using System.Diagnostics.CodeAnalysis;

namespace ProjetoPrevisaoTempo.Domain.Temperaturas
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
