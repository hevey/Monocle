#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build 
COPY src/Monocle/Server/Monocle.Server.csproj src/Monocle/Server/
COPY /src/Monocle/Client/Monocle.Client.csproj /src/Monocle/Client/
COPY /src/Monocle/Shared/Monocle.Shared.csproj /src/Monocle/Shared/
RUN dotnet restore "/src/Monocle/Server/Monocle.Server.csproj"
COPY ./src ./src

RUN dotnet build "/src/Monocle/Server/Monocle.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "/src/Monocle/Server/Monocle.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
RUN openssl req -x509 -newkey rsa:4096 -keyout key.pem -out cert.pem -days 365 -subj '/CN=localhost' -passout pass:"test"
RUN openssl pkcs12 -export -out cert.pfx -inkey key.pem -in cert.pem -passin pass:"test" -passout pass:"test"
ENTRYPOINT ["dotnet", "Monocle.Server.dll"]
