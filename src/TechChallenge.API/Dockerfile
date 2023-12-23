FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/TechChallenge.API/TechChallenge.API.csproj", "src/TechChallenge.API/"]
RUN dotnet restore "src/TechChallenge.API/TechChallenge.API.csproj"
COPY . .
WORKDIR "/src/src/TechChallenge.API"
RUN dotnet build "TechChallenge.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TechChallenge.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TechChallenge.API.dll"]
