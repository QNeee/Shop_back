# Build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# копіюємо solution folder
COPY shop_back/*.csproj ./shop_back/

RUN dotnet restore shop_back/Shop_back.csproj

# копіюємо весь код
COPY . .

RUN dotnet publish shop_back/Shop_back.csproj -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://0.0.0.0:8080

EXPOSE 8080

ENTRYPOINT ["dotnet", "Shop_back.dll"]