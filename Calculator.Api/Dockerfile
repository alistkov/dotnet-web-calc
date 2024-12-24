FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
#USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Debug
WORKDIR /src
COPY ["Calculator.Api/Calculator.Api.csproj", "Calculator.Api/"]
COPY ["Calculator.Lib/Calculator.Lib.csproj", "Calculator.Lib/"]
RUN dotnet restore "Calculator.Api/Calculator.Api.csproj"
COPY . .
WORKDIR "/src/Calculator.Api"
RUN dotnet build "Calculator.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Debug
RUN dotnet publish "Calculator.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_ENVIRONMENT=Development
ENTRYPOINT ["dotnet", "Calculator.Api.dll"]
