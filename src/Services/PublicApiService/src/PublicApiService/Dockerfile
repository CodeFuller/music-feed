FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /project
COPY ["src/PublicApiService/PublicApiService.csproj", "src/PublicApiService/"]
RUN dotnet restore "src/PublicApiService/PublicApiService.csproj"
COPY . .
WORKDIR "/project/src/PublicApiService"
RUN dotnet build "PublicApiService.csproj" --no-restore -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PublicApiService.csproj" --no-restore -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PublicApiService.dll"]
