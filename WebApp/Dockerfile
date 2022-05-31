FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app
EXPOSE 80

# copy csproj and restore as distinct layers
COPY *.props .
COPY *.sln .

COPY Base.Contracts.Base/*.csproj ./Base.Contracts.Base/
COPY Base.Contracts.Domain/*.csproj ./Base.Contracts.Domain/
COPY Base.Contracts.DAL/*.csproj ./Base.Contracts.DAL/
COPY Base.Contracts.BLL/*.csproj ./Base.Contracts.BLL/
COPY Helpers.WebApp/*.csproj ./Helpers.WebApp/
COPY Base.Resources/*.csproj ./Base.Resources/
COPY Base.Domain/*.csproj ./Base.Domain/
COPY Base.DAL/*.csproj ./Base.DAL/
COPY Base.BLL/*.csproj ./Base.BLL/
COPY Base.DAL.EF/*.csproj ./Base.DAL.EF/
COPY App.Resourses/*.csproj ./App.Resourses/
COPY App.Contracts.BLL/*.csproj ./App.Contracts.BLL/
COPY App.Contracts.DAL/*.csproj ./App.Contracts.DAL/
COPY App.Domain/*.csproj ./App.Domain/
COPY App.DAL.DTO/*.csproj ./App.DAL.DTO/
COPY App.BLL.DTO/*.csproj ./App.BLL.DTO/
COPY App.Public.DTO/*.csproj ./App.Public.DTO/
COPY App.DAL.EF/*.csproj ./App.DAL.EF/
COPY App.BLL/*.csproj ./App.BLL/
COPY Tests/*.csproj ./Tests/
COPY WebApp/*.csproj ./WebApp/

RUN dotnet restore

COPY Base.Contracts.Base/. ./Base.Contracts.Base/
COPY Base.Contracts.Domain/. ./Base.Contracts.Domain/
COPY Base.Contracts.DAL/. ./Base.Contracts.DAL/
COPY Base.Contracts.BLL/. ./Base.Contracts.BLL/
COPY Helpers.WebApp/. ./Helpers.WebApp/
COPY Base.Resources/. ./Base.Resources/
COPY Base.Domain/. ./Base.Domain/
COPY Base.DAL/. ./Base.DAL/
COPY Base.BLL/. ./Base.BLL/
COPY Base.DAL.EF/. ./Base.DAL.EF/
COPY App.Resourses/. ./App.Resourses/
COPY App.Contracts.BLL/. ./App.Contracts.BLL/
COPY App.Contracts.DAL/. ./App.Contracts.DAL/
COPY App.Domain/. ./App.Domain/
COPY App.DAL.DTO/. ./App.DAL.DTO/
COPY App.BLL.DTO/. ./App.BLL.DTO/
COPY App.Public.DTO/. ./App.Public.DTO/
COPY App.DAL.EF/. ./App.DAL.EF/
COPY App.BLL/. ./App.BLL/
COPY Tests/. ./Tests/
COPY WebApp/. ./WebApp/

WORKDIR /app/WebApp
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app

COPY --from=build /app/WebApp/out ./

ENTRYPOINT ["dotnet", "WebApp.dll"]