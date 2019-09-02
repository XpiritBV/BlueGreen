FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

ENV color=grey

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["BlueGreen/BlueGreen.csproj", "BlueGreen/"]
RUN dotnet restore "BlueGreen/BlueGreen.csproj"
COPY . .
WORKDIR "/src/BlueGreen"
RUN dotnet build "BlueGreen.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "BlueGreen.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "BlueGreen.dll"]