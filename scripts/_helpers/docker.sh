APP=$1
IMAGE=$2
CONTAINER=$3
PORT=$4

../_helpers/log.sh "Recriando Dockerfile..."
if [ -e "Dockerfile" ]; then
    rm Dockerfile
fi

cat >Dockerfile <<EOF1
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE $PORT

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["$APP/$APP.csproj", "$APP/"]
RUN dotnet restore "$APP/$APP.csproj"
COPY . .
WORKDIR "/src/$APP"
RUN dotnet build "$APP.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "$APP.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "$APP.dll"]
EOF1

../_helpers/log.sh "Reconstruindo container $IMAGE"
docker build --no-cache -f Dockerfile -t $IMAGE --network xpwebnet ../..

../_helpers/log.sh "Removendo container existente..."
docker container rm --force $CONTAINER

../_helpers/log.sh "Criando container..."
docker create --name=$CONTAINER \
    --publish=0.0.0.0:$PORT:80 \
    --network=xpwebnet \
    $IMAGE
    # --env="ASPNETCORE_URLS=http://+:$PORT" \
    # --env="API_URL=Api:$PORT" \

../_helpers/log.sh "Executando..."
docker container start $CONTAINER