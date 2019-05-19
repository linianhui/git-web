# https://hub.docker.com/_/microsoft-dotnet-core-aspnet/
# https://github.com/dotnet/dotnet-docker/blob/master/samples/aspnetapp/Dockerfile.alpine-x64
FROM mcr.microsoft.com/dotnet/core/sdk:2.2-alpine AS builder

COPY . /src

WORKDIR /src

RUN dotnet publish ./git.web/git.web.csproj --output /publish



FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-alpine

COPY --from=builder /publish /app

WORKDIR /app

EXPOSE 80

ENTRYPOINT ["dotnet", "Git.Web.dll"]