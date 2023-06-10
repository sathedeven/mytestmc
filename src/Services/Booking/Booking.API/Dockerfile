FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Services/Booking/Booking.API/Booking.API.csproj", "src/Services/Booking/Booking.API/"]
RUN dotnet restore "src/Services/Booking/Booking.API/Booking.API.csproj"
COPY . .
WORKDIR "/src/src/Services/Booking/Booking.API"
RUN dotnet build "Booking.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Booking.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Booking.API.dll"]