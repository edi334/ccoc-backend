# build backend
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS builder
WORKDIR /app/src

COPY ./*.sln .
COPY ./CCOCBackend.API/*.csproj ./CCOCBackend.API/
COPY ./CCOCBackend.API/nuget.config /root/.nuget/NuGet/NuGet.Config

ARG ENV_TYPE=CI_BUILD

WORKDIR /app/src/CCOCBackend.API
RUN dotnet restore

WORKDIR /app/src
COPY ./ ./

WORKDIR /app/src/CCOCBackend.API
RUN dotnet publish -c release -o /app/build

# runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 as runtime

RUN apt-get update && \
    apt install sudo -y \
 && rm -rf /var/lib/apt/lists/*

WORKDIR /app/bin
COPY --from=builder /app/build ./
COPY ./docker-entrypoint.sh ./
RUN chmod +x ./docker-entrypoint.sh

ENV NETCORE_USER_UID 1069
ENTRYPOINT ["./docker-entrypoint.sh"]
