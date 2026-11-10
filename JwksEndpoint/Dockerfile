
# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

WORKDIR /src

# Copy project file and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy remaining source code
COPY . .

# Compile and publish
RUN dotnet publish -c Release -o /app/publish

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime

WORKDIR /app

# Copy published application
COPY --from=build /app/publish .

# ASP.NET Core listening port
EXPOSE 8080

# Start application
ENTRYPOINT ["dotnet", "JwksEndpoint.dll"]