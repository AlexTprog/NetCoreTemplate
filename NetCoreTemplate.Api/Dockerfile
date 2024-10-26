# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
# Base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Build image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copiar el archivo de solución y los archivos de proyecto de cada capa
COPY ["../NetCoreTemplate.sln", "./"]
COPY ["NetCoreTemplate.Api/NetCoreTemplate.Api.csproj", "NetCoreTemplate.Api/"]
COPY ["../NetCoreTemplate.Application/NetCoreTemplate.Application.csproj", "NetCoreTemplate.Application/"]
COPY ["../NetCoreTemplate.Domain/NetCoreTemplate.Domain.csproj", "NetCoreTemplate.Domain/"]
COPY ["../NetCoreTemplate.Infrastructure/NetCoreTemplate.Infrastructure.csproj", "NetCoreTemplate.Infrastructure/"]

# Restaurar las dependencias
RUN dotnet restore

# Copiar todo el código fuente y construir la aplicación
COPY . .
WORKDIR "/src/NetCoreTemplate.Api"
RUN dotnet build "NetCoreTemplate.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publicar la aplicación
FROM build AS publish
RUN dotnet publish "NetCoreTemplate.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Imagen final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NetCoreTemplate.Api.dll"]
