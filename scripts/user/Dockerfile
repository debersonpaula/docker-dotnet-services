FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 16000

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Dock.Apps.UserApi/Dock.Apps.UserApi.csproj", "Dock.Apps.UserApi/"]
RUN dotnet restore "Dock.Apps.UserApi/Dock.Apps.UserApi.csproj"
COPY . .
WORKDIR "/src/Dock.Apps.UserApi"
RUN dotnet build "Dock.Apps.UserApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Dock.Apps.UserApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Dock.Apps.UserApi.dll"]
