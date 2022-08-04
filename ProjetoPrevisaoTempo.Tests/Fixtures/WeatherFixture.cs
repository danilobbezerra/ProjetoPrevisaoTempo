using Bogus;
using MongoDB.Bson;
using ProjetoPrevisaoTempo.Domain.Cidades;
using ProjetoPrevisaoTempo.Domain.Temperaturas;
using ProjetoPrevisaoTempo.Domain.Temperatures;

namespace ProjetoPrevisaoTempo.Tests.Fixtures
{
    public static class WeatherFixture
    {

        public static List<Weather> GetTestWatherList()
        {
            var fakeData = new Faker<Weather>();
            fakeData.RuleFor(s => s.Id, f => ObjectId.GenerateNewId());
            fakeData.RuleFor(s => s.Cnt, CntEnum.Grau);
            fakeData.RuleFor(s => s.Min, f => f.Random.Number(10));
            fakeData.RuleFor(s => s.Max, f => f.Random.Number(10));
            fakeData.RuleFor(s => s.City, GetCity());

            return fakeData.Generate(50);
        }

        public static Weather GetTestWatherSingle()
        {
            var fakeData = new Faker<Weather>();
            fakeData.RuleFor(s => s.Id, f => ObjectId.GenerateNewId());
            fakeData.RuleFor(s => s.Cnt, CntEnum.Grau);
            fakeData.RuleFor(s => s.Min, f => f.Random.Number(10));
            fakeData.RuleFor(s => s.Max, f => f.Random.Number(10));
            fakeData.RuleFor(s => s.City, f=> GetCity().Generate());

            return fakeData;
        }

        private static Faker<City> GetCity()
        {
            var fakeData = new Faker<City>();
            fakeData.RuleFor(s => s.Name, f=> f.Address.City());
            fakeData.RuleFor(s => s.Country, f => f.Address.Country());
            fakeData.RuleFor(s => s.Population, f => f.Random.Double());

            return fakeData;
        }

    }
}
