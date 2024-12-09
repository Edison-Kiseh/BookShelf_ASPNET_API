# Base runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0-preview AS base
WORKDIR /app
EXPOSE 80

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0-preview AS build
WORKDIR /src

# Copy project file(s) and restore dependencies
COPY *.csproj .
RUN dotnet restore
COPY . .

# Copy the rest of the source code
COPY .. .
WORKDIR "/src"

# Build the application
RUN dotnet build "ASPNET.csproj" -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish "ASPNET.csproj" -c Release -o /app/publish

# Final runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ASPNET.dll"]


