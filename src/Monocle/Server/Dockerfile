#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
COPY Monocle/Server/Monocle.Server.csproj Monocle/Server/
COPY Monocle/Client/Monocle.Client.csproj Monocle/Client/
COPY Monocle/Shared/Monocle.Shared.csproj Monocle/Shared/
RUN dotnet restore "Monocle/Server/Monocle.Server.csproj"
COPY . .
RUN dotnet build "Monocle/Server/Monocle.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Monocle/Server/Monocle.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Monocle.Server.dll"]
