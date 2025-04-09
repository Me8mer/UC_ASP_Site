# Use the official .NET SDK image to build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy everything
COPY . ./

# Publish to /out
RUN dotnet publish -c Release -o /out

# Use the ASP.NET runtime image to run
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /out ./
ENTRYPOINT ["dotnet", "UMBRAPage.dll"]
