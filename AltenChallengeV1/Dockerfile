FROM microsoft/aspnetcore:2.0 AS base
RUN apt-get -qq update && apt-get -qqy --no-install-recommends install wget gnupg \
    git \
    unzip

RUN curl -sL https://deb.nodesource.com/setup_7.x |  bash -
RUN apt-get install -y nodejs

WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY AltenChallengeV1.sln ./
COPY AltenChallengeV1/AltenChallengeV1.csproj AltenChallengeV1/
RUN dotnet restore -nowarn:msb3202,nu1503
COPY . .
WORKDIR /src/AltenChallengeV1
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "AltenChallengeV1.dll"]
