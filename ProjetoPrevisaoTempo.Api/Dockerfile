#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
#EXPOSE 80
#EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ProjetoPrevisaoTempo.Api/ProjetoPrevisaoTempo.Api.csproj", "ProjetoPrevisaoTempo.Api/"]
COPY ["ProjetoPrevisaoTempo.Infra.CrossCutting.IoC/ProjetoPrevisaoTempo.Infra.CrossCutting.IoC.csproj", "ProjetoPrevisaoTempo.Infra.CrossCutting.IoC/"]
COPY ["ProjetoPrevisaoTempo.Application/ProjetoPrevisaoTempo.Application.csproj", "ProjetoPrevisaoTempo.Application/"]
COPY ["ProjetoPrevisaoTempo.Domain/ProjetoPrevisaoTempo.Domain.csproj", "ProjetoPrevisaoTempo.Domain/"]
COPY ["ProjetoPrevisaoTempo.Infra.Data/ProjetoPrevisaoTempo.Infra.Data.csproj", "ProjetoPrevisaoTempo.Infra.Data/"]
RUN dotnet restore "ProjetoPrevisaoTempo.Api/ProjetoPrevisaoTempo.Api.csproj"
COPY . .
WORKDIR "/src/ProjetoPrevisaoTempo.Api"
RUN dotnet build "ProjetoPrevisaoTempo.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProjetoPrevisaoTempo.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProjetoPrevisaoTempo.Api.dll"]