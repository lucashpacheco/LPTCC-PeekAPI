#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Peek.API/Peek.API.csproj", "Peek.API/"]
RUN dotnet restore "Peek.API/Peek.API.csproj"
COPY . .
WORKDIR "/src/Peek.API"
RUN dotnet build "Peek.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Peek.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Peek.API.dll"]