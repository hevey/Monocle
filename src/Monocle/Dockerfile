#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
COPY src/Monocle/Monocle.csproj src/Monocle/
RUN dotnet restore "src/Monocle/Monocle.csproj"
COPY . .
RUN dotnet build "src/Monocle/Monocle.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "src/Monocle/Monocle.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Monocle.dll"]
