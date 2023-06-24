#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Puc.Web/Puc.Web.csproj", "Puc.Web/"]
RUN dotnet restore "Puc.Web/Puc.Web.csproj"
COPY . .
WORKDIR "/src/Puc.Web"
RUN dotnet build "Puc.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Puc.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Puc.Web.dll"]