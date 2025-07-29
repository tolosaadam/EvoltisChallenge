FROM mcr.microsoft.com/dotnet/aspnet:8.0-noble AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0-noble AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["src/EvoltisChallenge.Api.Application/EvoltisChallenge.Api.Application.csproj", "src/EvoltisChallenge.Api.Application/"]
COPY ["src/EvoltisChallenge.Api.Application.Interfaces/EvoltisChallenge.Api.Application.Interfaces.csproj", "src/EvoltisChallenge.Api.Application.Interfaces/"]
COPY ["src/EvoltisChallenge.Api.Domain/EvoltisChallenge.Api.Domain.csproj", "src/EvoltisChallenge.Api.Domain/"]
COPY ["src/EvoltisChallenge.Api.Infraestructure/EvoltisChallenge.Api.Infraestructure.csproj", "src/EvoltisChallenge.Api.Infraestructure/"]
COPY ["src/EvoltisChallenge.Api.Infraestructure.Repositories.Ef/EvoltisChallenge.Api.Infraestructure.Repositories.Ef.csproj", "src/EvoltisChallenge.Api.Infraestructure.Repositories.Ef/"]
COPY ["src/EvoltisChallenge.Api/EvoltisChallenge.Api.csproj", "src/EvoltisChallenge.Api/"]

RUN dotnet restore "src/EvoltisChallenge.Api/EvoltisChallenge.Api.csproj"

COPY . .

WORKDIR "/src/src/EvoltisChallenge.Api"
RUN dotnet build "EvoltisChallenge.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "EvoltisChallenge.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EvoltisChallenge.Api.dll"]
