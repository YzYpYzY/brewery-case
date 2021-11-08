# Preparation

## Requirements

- .NET 5 SDK https://dotnet.microsoft.com/download/dotnet/5.0

- dotnet-ef tool
  ```bash
  dotnet tool install --global dotnet-ef
  ```

## Prepare

Delete database > create database with migration > seed

```bash
rm -f db.sqlite
&& dotnet ef database update --project Brewery.Data/Brewery.Data.csproj -c BreweryDbContext
&& cd Brewery.Seed
&& dotnet run
&& cd ..
```

## Other commands

```bash
dotnet ef migrations add InitialCreate --project Brewery.Data/Brewery.Data.csproj
```
