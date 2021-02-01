FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

COPY ["src/UpdatesService/UpdatesService.csproj", "/project/src/UpdatesService/"]
# UpdatesService.Client is not published within an image, but this project is used by UpdatesService.IntegrationTests
COPY ["src/UpdatesService.Client/UpdatesService.Client.csproj", "/project/src/UpdatesService.Client/"]
COPY ["tests/UpdatesService.IntegrationTests/UpdatesService.IntegrationTests.csproj", "/project/tests/UpdatesService.IntegrationTests/"]
COPY ["UpdatesService.sln", "/project/"]
RUN dotnet restore "/project/UpdatesService.sln"

COPY . "/project/"

RUN dotnet build "/project/UpdatesService.sln" --no-restore -c Release

RUN dotnet test "/project/UpdatesService.sln" --no-build -c Release --logger "trx;LogFileName=UpdatesService.trx" 

FROM build AS publish
RUN dotnet publish "/project/src/UpdatesService/UpdatesService.csproj" --no-restore -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish /app
ENTRYPOINT ["dotnet", "UpdatesService.dll"]
