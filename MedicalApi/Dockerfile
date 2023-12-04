# Gebruik een basisimage met de SDK van .NET Core om de applicatie te bouwen
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

# Stel de werkdirectory in binnen de container
WORKDIR /app

# Kopieer de projectbestanden naar de werkdirectory
COPY . .

# Restore de benodigde pakketten met behulp van de projectoplossing
RUN dotnet restore

# Voer de build uit van de applicatie
RUN dotnet build -c Release -o /app/build

# Voer de publish uit van de applicatie
RUN dotnet publish -c Release -o /app/publish

# Bouw de runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime

# Werkdirectory instellen voor de runtime image
WORKDIR /app

# Kopieer de gepubliceerde bestanden van de build image naar de runtime image
COPY --from=build /app/publish .

# Expose de poort waarop de API draait
EXPOSE 3003

# Start de ASP.NET Core-applicatie
ENTRYPOINT ["dotnet", "MedicalApi.dll"]
