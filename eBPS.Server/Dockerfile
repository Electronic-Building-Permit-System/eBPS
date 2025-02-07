# Use official .NET 8 runtime as base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5000

# Use .NET 8 SDK for building the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the project file and restore dependencies
COPY ["eBPS.Server/eBPS.Server.csproj", "eBPS.Server/"]
RUN dotnet restore "eBPS.Server/eBPS.Server.csproj"

# Copy everything and build the application
COPY . .
WORKDIR "/src/eBPS.Server"
RUN dotnet publish -c Release -o /app/publish

# Final image to run the app
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "eBPS.Server.dll"]
