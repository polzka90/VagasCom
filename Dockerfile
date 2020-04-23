FROM mcr.microsoft.com/dotnet/core/sdk:3.1-bionic AS build-env
WORKDIR /app
# Build da aplicacao
COPY . ./
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Build da imagem
#FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-bionic
WORKDIR /app
COPY --from=build-env /app/out .
ENV ASPNETCORE_URLS="http://*:80"
EXPOSE 80/tcp
EXPOSE 5432
ENTRYPOINT ["dotnet", "VagasCom.Api.dll"]