using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using ProjetoPrevisaoTempo.Api.Controllers;
using ProjetoPrevisaoTempo.Application.Interfaces;
using ProjetoPrevisaoTempo.Application.Services;
using ProjetoPrevisaoTempo.Domain.Weathers;
using ProjetoPrevisaoTempo.Tests.Fixtures;

namespace ProjetoPrevisaoTempo.Tests
{
    public class TestWeaTherController
    {
        [Theory]
        [InlineData(TypeTempEnum.Hot, 3)]
        [InlineData(TypeTempEnum.Cold, 3)]
        public async Task Get_CityesByTypeTemp_OnSuccess_ReturnsStausCode200(TypeTempEnum type, int total)
        {
            //Arrange
            var mockWeatherService = new Mock<IWeatherService>();
            mockWeatherService.Setup(x => x.GetCityesTempToday(type, total)).Returns(Task.FromResult(WeatherFixture.GetTestWatherList()));

            var sut = new WeatherForecastController(new Mock<ILogger<WeatherForecastController>>().Object, mockWeatherService.Object);

            //Act
            var result = (OkObjectResult)await sut.GetCityesTempToday(type.ToString());

            //Assert
            result.StatusCode.Should().Be(200);

        }

        [Theory]
        [InlineData(TypeTempEnum.Hot, 3)]
        [InlineData(TypeTempEnum.Cold, 3)]
        public async Task Get_CityesByTypeTemp_OnSuccess_ReturnsStausCode200_and_total_equals_request(TypeTempEnum type, int total)
        {
            //Arrange
            var mockWeatherService = new Mock<IWeatherService>();
            mockWeatherService.Setup(x => x.GetCityesTempToday(type, total)).Returns(Task.FromResult(WeatherFixture.GetTestWatherList().Take(total).ToList()));

            var sut = new WeatherForecastController(new Mock<ILogger<WeatherForecastController>>().Object, mockWeatherService.Object);

            //Act
            var result = await sut.GetCityesTempToday(type.ToString(), total);

            var okResult = result as OkObjectResult;
            var values = okResult?.Value as List<Weather>;

            //Assert
            okResult.StatusCode.Should().Be(200);
            values.Count.Should().Be(total);
        }


        [Theory]
        [InlineData(TypeTempEnum.Hot, 3)]
        [InlineData(TypeTempEnum.Cold, 3)]
        public async Task Get_CityesByTypeTemp_OnSuccess_InvokeWatherService(TypeTempEnum type, int total)
        {
            //Arrange
            var mockWeatherService = new Mock<IWeatherService>();
            mockWeatherService.Setup(x => x.GetCityesTempToday(type, total)).Returns(Task.FromResult(new List<Weather>()));


            var sut = new WeatherForecastController(new Mock<ILogger<WeatherForecastController>>().Object, mockWeatherService.Object);

            //Act
            var result = await sut.GetCityesTempToday(type.ToString());


            //Assert
            mockWeatherService.Verify(
                service => service.GetCityesTempToday(type, total), 
                Times.Once
            );
        }


        [Theory]
        [InlineData(TypeTempEnum.Hot, 3)]
        [InlineData(TypeTempEnum.Cold, 3)]
        public async Task Get_CityesByTypeTemp_OnSuccess_ReturnWeather(TypeTempEnum type, int total)
        {
            //Arrange
            var mockWeatherService = new Mock<IWeatherService>();
            mockWeatherService.Setup(x => x.GetCityesTempToday(type, total)).Returns(Task.FromResult(WeatherFixture.GetTestWatherList()));

            var sut = new WeatherForecastController(new Mock<ILogger<WeatherForecastController>>().Object, mockWeatherService.Object);

            //Act
            var result = await sut.GetCityesTempToday(type.ToString(), total);

            //Assert
            result.Should().BeOfType<OkObjectResult>();
            var objectResult = (OkObjectResult)result;
            objectResult.Value.Should().BeOfType<List<Weather>>();

        }


        [Theory]
        [InlineData(TypeTempEnum.Hot, 3)]
        [InlineData(TypeTempEnum.Cold, 3)]
        public async Task Get_HotCityes_NoWeatherFound_Return404(TypeTempEnum type, int total)
        {
            //Arrange
            var mockWeatherService = new Mock<IWeatherService>();

            mockWeatherService.Setup(x => x.GetCityesTempToday(type, total)).Returns(Task.FromResult(new List<Weather>()));

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