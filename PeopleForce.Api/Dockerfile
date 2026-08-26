FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["PeopleForce.Api/PeopleForce.Api.csproj", "PeopleForce.Api/"]
COPY ["PeopleForce.Application/PeopleForce.Application.csproj", "PeopleForce.Application/"]
COPY ["PeopleForce.Domain/PeopleForce.Domain.csproj", "PeopleForce.Domain/"]
COPY ["PeopleForce.Infrastructure/PeopleForce.Infrastructure.csproj", "PeopleForce.Infrastructure/"]

RUN dotnet restore "PeopleForce.Api/PeopleForce.Api.csproj"

COPY . .

WORKDIR "/src/PeopleForce.Api"
RUN dotnet build "PeopleForce.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release

RUN dotnet publish "PeopleForce.Api.csproj" \
    -c $BUILD_CONFIGURATION \
    -o /app/publish \
    /p:UseAppHost=false

FROM base AS final
WORKDIR /app

COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "PeopleForce.Api.dll"]