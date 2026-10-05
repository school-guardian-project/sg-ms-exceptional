FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/ms-exceptional.Api/ms-exceptional.Api.csproj", "src/ms-exceptional.Api/"]
RUN dotnet restore "src/ms-exceptional.Api/ms-exceptional.Api.csproj"
COPY . .
WORKDIR "/src/src/ms-exceptional.Api"
RUN dotnet build "./ms-exceptional.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
WORKDIR "/src/src/ms-exceptional.Api"
RUN dotnet publish "./ms-exceptional.Api.csproj" -c $BUILD_CONFIGURATION -o /App/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /App/publish .
ENTRYPOINT ["dotnet", "ms-exceptional.Api.dll"]
