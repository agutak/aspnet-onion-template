#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#if (Framework == 'net6.0')
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
#endif
#if (Framework == 'net7.0')
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
#endif
#if (Framework == 'net8.0')
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
#endif
USER app
WORKDIR /app
EXPOSE 5000

#if (Framework == 'net6.0')
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
#endif
#if (Framework == 'net7.0')
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
#endif
#if (Framework == 'net8.0')
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
#endif
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/MyTemplate.API/MyTemplate.API.csproj", "src/MyTemplate.API/"]
RUN dotnet restore "src/MyTemplate.API/MyTemplate.API.csproj"
COPY . .
WORKDIR "/src/src/MyTemplate.API"
RUN dotnet build "MyTemplate.API.csproj" -c ${BUILD_CONFIGURATION} --no-restore

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "MyTemplate.API.csproj" -c ${BUILD_CONFIGURATION} -o /app/publish --no-build

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyTemplate.API.dll"]