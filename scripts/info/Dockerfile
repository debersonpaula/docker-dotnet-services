FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Dock.Apps.InfoApi/Dock.Apps.InfoApi.csproj", "Dock.Apps.InfoApi/"]
RUN dotnet restore "Dock.Apps.InfoApi/Dock.Apps.InfoApi.csproj"
COPY . .
WORKDIR "/src/Dock.Apps.InfoApi"
RUN dotnet build "Dock.Apps.InfoApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Dock.Apps.InfoApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Dock.Apps.InfoApi.dll"]
