FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app
EXPOSE 8080

WORKDIR /source
COPY KudryavtsevAlexey.Forum.sln ./
COPY KudryavtsevAlexey.Forum.Domain/KudryavtsevAlexey.Forum.Domain.csproj ./KudryavtsevAlexey.Forum.Domain/
COPY KudryavtsevAlexey.Forum.Infrastructure/KudryavtsevAlexey.Forum.Infrastructure.csproj ./KudryavtsevAlexey.Forum.Infrastructure/
COPY KudryavtsevAlexey.Forum.Services/KudryavtsevAlexey.Forum.Services.csproj ./KudryavtsevAlexey.Forum.Services/
COPY KudryavtsevAlexey.Forum.IntegrationTests/KudryavtsevAlexey.Forum.IntegrationTests.csproj ./KudryavtsevAlexey.Forum.IntegrationTests/
COPY KudryavtsevAlexey.Forum.Api/KudryavtsevAlexey.Forum.Api.csproj ./KudryavtsevAlexey.Forum.Api/
RUN dotnet restore

COPY . .

WORKDIR /source/KudryavtsevAlexey.Forum.Domain
RUN dotnet build -c Release -o /app

WORKDIR /source/KudryavtsevAlexey.Forum.Infrastructure
RUN dotnet build -c Release -o /app

WORKDIR /source/KudryavtsevAlexey.Forum.Services
RUN dotnet build -c Release -o /app

WORKDIR /source/KudryavtsevAlexey.Forum.IntegrationTests
RUN dotnet build -c Release -o /app

WORKDIR /source/KudryavtsevAlexey.Forum.Api
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "KudryavtsevAlexey.Forum.Api.dll"]