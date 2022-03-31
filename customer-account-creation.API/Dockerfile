#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["customer-account-creation.API/customer-account-creation.API.csproj", "customer-account-creation.API/"]
RUN dotnet restore "customer-account-creation.API/customer-account-creation.API.csproj"
COPY . .
WORKDIR "/src/customer-account-creation.API"
RUN dotnet build "customer-account-creation.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "customer-account-creation.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "customer-account-creation.API.dll"]