#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["src/SistemaVotacao.Api/SistemaVotacao.Api.csproj", "src/SistemaVotacao.Api/"]
COPY ["src/SistemaVotacao.Ioc/SistemaVotacao.Ioc.csproj", "src/SistemaVotacao.Ioc/"]
COPY ["src/SistemaVotacao.Dados/SistemaVotacao.Dados.csproj", "src/SistemaVotacao.Dados/"]
COPY ["src/SistemaVotacao.Dominio/SistemaVotacao.Dominio.csproj", "src/SistemaVotacao.Dominio/"]
RUN dotnet restore "src/SistemaVotacao.Api/SistemaVotacao.Api.csproj"
COPY . .
WORKDIR "src/SistemaVotacao.Api/"
RUN dotnet build "SistemaVotacao.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SistemaVotacao.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SistemaVotacao.Api.dll"]