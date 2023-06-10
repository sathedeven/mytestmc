FROM dotnet/runtime:7.0.5-nanoserver-1809 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Services/Tracking/Tracking.API/Tracking.API.csproj", "src/Services/Tracking/Tracking.API/"]
RUN dotnet restore "src/Services/Tracking/Tracking.API/Tracking.API.csproj"
COPY . .
WORKDIR "/src/src/Services/Tracking/Tracking.API"
RUN dotnet build "Tracking.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Tracking.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Tracking.API.dll"]