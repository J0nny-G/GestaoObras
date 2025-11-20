# Imagem base de runtime (onde a app vai correr)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# Imagem de SDK para compilar/publicar
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar o ficheiro .csproj e restaurar dependências
COPY *.csproj ./
RUN dotnet restore

# Copiar o resto do código
COPY . .

# Publicar em modo Release para uma pasta "publish"
RUN dotnet publish -c Release -o /app/publish

# Imagem final (runtime apenas)
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "GestaoObras.dll"]
