FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app
EXPOSE 80

# copy csproj and restore as distinct layers
COPY *.props .
COPY *.sln .

COPY WebAppDocker/*.csproj ./WebAppDocker/

RUN dotnet restore

COPY WebAppDocker/. ./WebAppDocker/

WORKDIR /app/WebAppDocker
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app

COPY --from=build /app/WebAppDocker/out ./

ENTRYPOINT ["dotnet", "WebAppDocker.dll"]