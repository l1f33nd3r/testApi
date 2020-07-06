#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["TestHttp/TestHttp.csproj", "TestHttp/"]
RUN dotnet restore "TestHttp/TestHttp.csproj"
COPY . .
WORKDIR "/src/TestHttp"
RUN dotnet build "TestHttp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestHttp.csproj" -c Release -o /app/publish

FROM base AS final
EXPOSE 80/tcp
EXPOSE 443/tcp
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestHttp.dll"]