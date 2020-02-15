FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .
COPY WebAPI/*.csproj ./WebAPI/
COPY Random/*.csproj ./Random/
RUN dotnet restore WebAPI/WebAPI.csproj

# copy everything else and build app
COPY WebAPI/. ./WebAPI/
COPY Random/. ./Random/
WORKDIR /source/WebAPI
RUN dotnet build -c release

FROM build AS publish
RUN dotnet publish -c release --no-build -o /app

# final stage/image
FROM mcr.microsoft.com/dotnet/core/runtime:3.1
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WebAPI.dll"]


## test stage -- exposes optional entrypoint
## target entrypoint with: docker build --target test
#FROM build AS test
#WORKDIR /source/tests
#COPY tests/ .
#ENTRYPOINT ["dotnet", "test", "--logger:trx"]