# Use the official Microsoft .NET SDK image to build the project
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy csproj and restore dependencies
COPY ["Digital.Api.csproj", "./"]
RUN dotnet restore "Digital.Api.csproj"

# Copy everything else and build the release project
COPY . .
RUN dotnet build "Digital.Api.csproj" -c Release -o /app/build

# Publish the project
FROM build AS publish
RUN dotnet publish "Digital.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Generate runtime image
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080
ENTRYPOINT ["dotnet", "Digital.Api.dll"]
