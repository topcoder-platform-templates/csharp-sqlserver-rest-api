FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY WebAPI/WebAPI.csproj WebAPI/
RUN dotnet restore WebAPI/WebAPI.csproj
COPY . .
WORKDIR /src/WebAPI
RUN dotnet build WebAPI.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish WebAPI.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WebAPI.dll"]
