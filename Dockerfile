FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Nordlager.Backend/Nordlager.Backend.csproj", "Nordlager.Backend/"]
COPY ["Nordlager.Shared/Nordlager.Shared.csproj", "Nordlager.Shared/"]
RUN dotnet restore "Nordlager.Backend/Nordlager.Backend.csproj"
COPY . .
WORKDIR "/src/Nordlager.Backend"
RUN dotnet build "Nordlager.Backend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Nordlager.Backend.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Nordlager.Backend.dll"]