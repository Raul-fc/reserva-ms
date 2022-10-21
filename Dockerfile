FROM centos:7 AS base

# Add Microsoft package repository and install ASP.NET Core
RUN rpm -Uvh https://packages.microsoft.com/config/centos/7/packages-microsoft-prod.rpm \
    && yum install -y aspnetcore-runtime-5.0

# Ensure we listen on any IP Address 
ENV DOTNET_URLS=http://+:5000

WORKDIR /app

# ... remainder of dockerfile as before
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["./Reservas.WebApi/Reservas.WebApi.csproj", "src/Reservas.WebApi/"]
RUN dotnet restore "src/Reservas.WebApi/Reservas.WebApi.csproj"
COPY . .
WORKDIR "/src/Reservas.WebApi/"
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Reservas.WebApi.dll"]