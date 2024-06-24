FrogPay Store Registry
Este projeto é uma API para o registro de lojas no FrogPay. A aplicação foi desenvolvida em .NET Core e utiliza um banco de dados PostgreSQL.

Requisitos
Docker
Docker Compose
.NET SDK 8.0
Configuração
1. Configurar o Banco de Dados PostgreSQL
Primeiro, você precisa criar um contêiner Docker para o PostgreSQL. Use o seguinte comando:

bash
Copiar código
docker run --name postgres-db -e POSTGRES_PASSWORD=teste123 -e POSTGRES_DB=StoreRegistryDB -p 5432:5432 -d postgres
2. Configurar a Aplicação .NET
Atualize sua string de conexão no arquivo appsettings.json:

json
Copiar código
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=postgres-db;Port=5432;Database=StoreRegistryDB;Username=postgres;Password=teste123"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
3. Criar o Dockerfile
Crie um arquivo chamado Dockerfile no diretório raiz do seu projeto com o seguinte conteúdo:

dockerfile
Copiar código
# Use the official .NET image for the base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Use the official .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["FrogPay.StoreRegistry/FrogPay.StoreRegistry.csproj", "FrogPay.StoreRegistry/"]
RUN dotnet restore "FrogPay.StoreRegistry/FrogPay.StoreRegistry.csproj"
COPY . .
WORKDIR "/src/FrogPay.StoreRegistry"
RUN dotnet build "FrogPay.StoreRegistry.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FrogPay.StoreRegistry.csproj" -c Release -o /app/publish

# Use the base image to run the application
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FrogPay.StoreRegistry.dll"]
4. Criar o docker-compose.yml
Crie um arquivo chamado docker-compose.yml no diretório raiz do seu projeto com o seguinte conteúdo:

yaml
Copiar código
version: '3.4'

services:
  postgres-db:
    image: postgres
    environment:
      POSTGRES_PASSWORD: teste123
      POSTGRES_DB: StoreRegistryDB
    ports:
      - "5432:5432"
    volumes:
      - postgres-data:/var/lib/postgresql/data

  webapp:
    build:
      context: .
      dockerfile: Dockerfile
    depends_on:
      - postgres-db
    environment:
      - ASPNETCORE_ENVIRONMENT=Development
      - ConnectionStrings__DefaultConnection=Host=postgres-db;Port=5432;Database=StoreRegistryDB;Username=postgres;Password=teste123
    ports:
      - "5000:80"
      - "5001:443"
    volumes:
      - ./logs:/app/logs

volumes:
  postgres-data:
5. Construir e Executar os Contêineres
Para construir a imagem da sua aplicação e iniciar os contêineres, use os seguintes comandos:

bash
Copiar código
docker-compose build
docker-compose up
6. Parar os Contêineres
Para parar os contêineres, use o seguinte comando:

bash
Copiar código
docker-compose down
Observações
Certifique-se de que o Docker e o Docker Compose estão instalados e funcionando corretamente no seu sistema.
Caso encontre algum problema, verifique os logs dos contêineres para obter mais informações.