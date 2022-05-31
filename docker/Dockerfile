FROM mcr.microsoft.com/dotnet/sdk:latest AS build
WORKDIR /app
EXPOSE 80

# copy csproj and restore as distinct layers
COPY *.props .
COPY *.sln .

COPY WebApp/*.csproj ./WebApp/

RUN dotnet restore

COPY WebApp/. ./WebApp/

WORKDIR /app/WebApp
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:latest AS runtime
WORKDIR /app

COPY --from=build /app/WebApp/out ./

ENTRYPOINT ["dotnet", "WebApp.dll"]