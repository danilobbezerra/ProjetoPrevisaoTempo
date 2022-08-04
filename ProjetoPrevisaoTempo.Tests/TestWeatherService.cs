using FluentAssertions;
using Moq;
using ProjetoPrevisaoTempo.Application.Services;
using ProjetoPrevisaoTempo.Domain.Temperaturas;
using ProjetoPrevisaoTempo.Infra.Data.Repository;
using ProjetoPrevisaoTempo.Infra.Data.UoW;
using ProjetoPrevisaoTempo.Tests.Fixtures;

namespace ProjetoPrevisaoTempo.Tests
{
    public class TestWeaTherService
    {
        [Theory]
        [InlineData(TypeTempEnum.Hot)]
        [InlineData(TypeTempEnum.Cold)]
        public async Task Return_Weather(TypeTempEnum type)
        {
            var mockRepository = new Mock<IWeatherRepository>();
            var mockUow = new Mock<IUnitOfWork>();
            mockRepository.Setup(x => x.GetAll()).ReturnsAsync(WeatherFixture.GetTestWatherList());

            var service = new WeatherService(mockRepository.Object, mockUow.Object);

            var result = await service.GetCityesTempToday(type);

            result.Should().NotBeNull();
        }

        [Fact]
        public async Task Return_null_when_enum_not_implemented()
        {
            var mockRepository = new Mock<IWeatherRepository>();
            var mockUow = new Mock<IUnitOfWork>();
            mockRepository.Setup(x => x.GetAll()).ReturnsAsync(new List<Weather>());

            var service = new WeatherService(mockRepository.Object, mockUow.Object);

            var result = await service.GetCityesTempToday(TypeTempEnum.MoreOrLess);

            result.Should().BeNull();
        }

        [Fact]
        public async Task Return_success_on_create_data_list()
        {
            var mockRepository = new Mock<IWeatherRepository>();
            var mockUow = new Mock<IUnitOfWork>();
            mockRepository.Setup(x => x.Add(new List<Weather>()));
            mockUow.Setup(x => x.Commit()).ReturnsAsync(true);

            var service = new WeatherService(mockRepository.Object, mockUow.Object);

            var result = await service.Create(WeatherFixture.GetTestWatherList());

            result.Should().BeTrue();
        }

        [Fact]
        public async Task Return_success_on_create_single()
        {
            var mockRepository = new Mock<IWeatherRepository>();
            var mockUow = new Mock<IUnitOfWork>();
            mockRepository.Setup(x => x.Add(new Weather()));
            mockUow.Setup(x => x.Commit()).ReturnsAsync(true);

            var service = new WeatherService(mockRepository.Object, mockUow.Object);

            var result = await service.Create(WeatherFixture.GetTestWatherSingle());

            result.Should().BeTrue();
        }

        [Fact]
        public async Task Return_error_when_list_no_elements_on_create_data()
        {
            var mockRepository = new Mock<IWeatherRepository>();
            var mockUow = new Mock<IUnitOfWork>();
            mockRepository.Setup(x => x.Add(new List<Weather>()));
            mockUow.Setup(x => x.Commit()).ReturnsAsync(true);

            var service = new WeatherService(mockRepository.Object, mockUow.Object);

            var result = await service.Create(new List<Weather>());

            result.Should().BeFalse();
        }

        [Fact]
        public async Task Return_error_when_single_no_elements_on_create_data()
        {
            var mockRepository = new Mock<IWeatherRepository>();
            var mockUow = new Mock<IUnitOfWork>();
            mockRepository.Setup(x => x.Add(new Weather()));
            mockUow.Setup(x => x.Commit()).ReturnsAsync(true);

            var service = new WeatherService(mockRepository.Object, mockUow.Object);

            var result = await service.Create(new Weather());

            result.Should().BeFalse();
        }
    }
}
