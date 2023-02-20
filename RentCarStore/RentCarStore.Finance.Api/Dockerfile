#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["RentCarStore.Finance.Api/RentCarStore.Finance.Api.csproj", "RentCarStore.Finance.Api/"]
RUN dotnet restore "RentCarStore.Finance.Api/RentCarStore.Finance.Api.csproj"
COPY . .
WORKDIR "/src/RentCarStore.Finance.Api"
RUN dotnet build "RentCarStore.Finance.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RentCarStore.Finance.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RentCarStore.Finance.Api.dll"]