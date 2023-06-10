FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app
EXPOSE 5004

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Web/MicroCourier.Web/MicroCourier.Web.csproj", "src/Web/MicroCourier.Web/"]
RUN dotnet restore "src/Web/MicroCourier.Web/MicroCourier.Web.csproj"
COPY . .
WORKDIR "/src/src/Web/MicroCourier.Web"
RUN dotnet build "MicroCourier.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "MicroCourier.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MicroCourier.Web.dll"]