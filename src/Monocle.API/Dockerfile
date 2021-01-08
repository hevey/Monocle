#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
COPY src/Monocle.API/Monocle.API.csproj src/Monocle.API/
RUN dotnet restore "src/Monocle.API/Monocle.API.csproj"
COPY . .
RUN dotnet build "src/Monocle.API/Monocle.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "src/Monocle.API/Monocle.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Monocle.API.dll"]
