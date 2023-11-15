FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SunnyRewards.HelloWorld.Api/SunnyRewards.HelloWorld.Api.csproj", "SunnyRewards.HelloWorld.Api/"]
COPY ["SunnyRewards.HelloWorld.Common/SunnyRewards.HelloWorld.Common.csproj", "SunnyRewards.HelloWorld.Common/"]
RUN dotnet restore "SunnyRewards.HelloWorld.Api/SunnyRewards.HelloWorld.Api.csproj"
COPY . .
WORKDIR "/src/SunnyRewards.HelloWorld.Api"
RUN dotnet build "SunnyRewards.HelloWorld.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SunnyRewards.HelloWorld.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SunnyRewards.HelloWorld.Api.dll"]
