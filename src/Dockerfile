FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app
EXPOSE 6000
# copy csproj and restore as distinct layers
COPY *.sln .
COPY WebAPI/*.csproj ./WebAPI/
RUN dotnet restore

# copy everything else and build app
COPY WebAPI/. ./WebAPI/
WORKDIR /app/WebAPI
RUN dotnet publish -c Release -o out


FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
COPY --from=build /app/WebAPI/out ./
ENTRYPOINT ["dotnet", "WebAPI.dll"]
