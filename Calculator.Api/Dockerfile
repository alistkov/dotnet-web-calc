FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Calculator.Api/Calculator.Api.csproj", "Calculator.Api/"]
COPY ["Calculator.Domain/Calculator.Domain.csproj", "Calculator.Domain/"]
COPY ["Calculator.Application/Calculator.Application.csproj", "Calculator.Application/"]
RUN dotnet restore "Calculator.Api/Calculator.Api.csproj"
COPY . .
WORKDIR "/src/Calculator.Api"
RUN dotnet build "Calculator.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Calculator.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_ENVIRONMENT=Development
ENTRYPOINT ["dotnet", "Calculator.Api.dll"]
