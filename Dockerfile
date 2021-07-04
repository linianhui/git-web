# https://hub.docker.com/_/microsoft-dotnet-sdk/
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS builder

COPY . /build

WORKDIR /build

RUN dotnet publish /build/src/git.web/git.web.csproj --output /publish



FROM mcr.microsoft.com/dotnet/aspnet:5.0

COPY --from=builder /publish /app

WORKDIR /app

EXPOSE 80

ENTRYPOINT ["dotnet", "Git.Web.dll"]