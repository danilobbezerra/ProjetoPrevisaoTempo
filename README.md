# Projeto Previsão do Tempo

## Technologies implemented:

- ASP.NET 6.0
- ASP.NET MVC Core 
- .NET Core Native DI
- Swagger

## Architecture:

- Full architecture with responsibility separation concerns, SOLID and Clean Code
- Domain Driven Design (Layers and Domain Model Pattern)
- Unit of Work
- Repository

## Tests:

- Mock (Moq)
- Fluentassertions
- FakeData (Bogus)

## DataBase:

- MongoDB


## Container:

- Docker
- Docker-Compose


## How To run this project:

- In root folder run command: docker-compose up -d
- Aceess a API swagger: http://localhost:5002/swagger
- Call endpoint PUT:  /WeatherForecast
- Access front-end:  http://localhost:5001