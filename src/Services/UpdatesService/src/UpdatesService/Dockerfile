FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /project
COPY ["src/UpdatesService/UpdatesService.csproj", "src/UpdatesService/"]
RUN dotnet restore "src/UpdatesService/UpdatesService.csproj"
COPY . .
WORKDIR "/project/src/UpdatesService"
RUN dotnet build "UpdatesService.csproj" --no-restore -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UpdatesService.csproj" --no-restore -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UpdatesService.dll"]
