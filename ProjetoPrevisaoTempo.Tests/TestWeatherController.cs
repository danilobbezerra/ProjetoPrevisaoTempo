using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using ProjetoPrevisaoTempo.Api.Controllers;
using ProjetoPrevisaoTempo.Application.Interfaces;
using ProjetoPrevisaoTempo.Application.Services;
using ProjetoPrevisaoTempo.Domain.Temperaturas;
using ProjetoPrevisaoTempo.Tests.Fixtures;

namespace ProjetoPrevisaoTempo.Tests
{
    public class TestWeaTherController
    {
        [Theory]
        [InlineData(TypeTempEnum.Hot)]
        [InlineData(TypeTempEnum.Cold)]
        public async Task Get_CityesByTypeTemp_OnSuccess_ReturnsStausCode200(TypeTempEnum type)
        {
            //Arrange
            var mockWeatherService = new Mock<IWeatherService>();
            mockWeatherService.Setup(x => x.GetCityesTempToday(type)).Returns(Task.FromResult(WeatherFixture.GetTestWatherSingle()));

            var sut = new WeatherForecastController(new Mock<ILogger<WeatherForecastController>>().Object, mockWeatherService.Object);

            //Act
            var result = (OkObjectResult)await sut.GetCityesTempToday(type.ToString());

            //Assert
            result.StatusCode.Should().Be(200);
        }

        [Theory]
        [InlineData(TypeTempEnum.Hot)]
        [InlineData(TypeTempEnum.Cold)]
        public async Task Get_CityesByTypeTemp_OnSuccess_InvokeWatherService(TypeTempEnum type)
        {
            //Arrange
            var mockWeatherService = new Mock<IWeatherService>();
            mockWeatherService.Setup(x => x.GetCityesTempToday(type)).Returns(Task.FromResult(new Weather()));


            var sut = new WeatherForecastController(new Mock<ILogger<WeatherForecastController>>().Object, mockWeatherService.Object);

            //Act
            var result = await sut.GetCityesTempToday(type.ToString());


            //Assert
            mockWeatherService.Verify(
                service => service.GetCityesTempToday(type), 
                Times.Once
            );
        }


        [Theory]
        [InlineData(TypeTempEnum.Hot)]
        [InlineData(TypeTempEnum.Cold)]
        public async Task Get_CityesByTypeTemp_OnSuccess_ReturnWeather(TypeTempEnum type)
        {
            //Arrange
            var mockWeatherService = new Mock<IWeatherService>();
            mockWeatherService.Setup(x => x.GetCityesTempToday(type)).Returns(Task.FromResult(WeatherFixture.GetTestWatherSingle()));

            var sut = new WeatherForecastController(new Mock<ILogger<WeatherForecastController>>().Object, mockWeatherService.Object);

            //Act
            var result = await sut.GetCityesTempToday(type.ToString());

            //Assert
            result.Should().BeOfType<OkObjectResult>();
            var objectResult = (OkObjectResult)result;
            objectResult.Value.Should().BeOfType<Weather>();

        }


        [Theory]
        [InlineData(TypeTempEnum.Hot)]
        [InlineData(TypeTempEnum.Cold)]
        public async Task Get_HotCityes_NoWeatherFound_Return404(TypeTempEnum type)
        {
            //Arrange
            var mockWeatherService = new Mock<IWeatherService>();

            mockWeatherService.Setup(x => x.GetCityesTempToday(type)).Returns(Task.FromResult(new Weather()));

            var sut = new WeatherForecastController(new Mock<ILogger<WeatherForecastController>>().Object, mockWeatherService.Object);

            //Act
            var result = await sut.GetCityesTempToday(type.ToString());

            //Assert
            result.Should().BeOfType<NotFoundResult>();

        }

        [Fact]
        public async Task Get_CityesByTypeTemp_InvalidParamType_ReturnBadRequest()
        {
            //Arrange
            var mockWeatherService = new Mock<IWeatherService>();

            //mockWeatherService.Setup(x => x.GetCityesTempToday()).Returns(Task.FromResult(new List<Weather>()));

            var sut = new WeatherForecastController(new Mock<ILogger<WeatherForecastController>>().Object, mockWeatherService.Object);

            //Act
            var result = await sut.GetCityesTempToday("xxxx");

            //Assert
            result.Should().BeOfType<BadRequestResult>();

        }
    }
}