# Gestão de Obras
Aplicação Web desenvolvida em ASP.NET Core MVC com Entity Framework Core e PostgreSQL.
O projeto permite gerir Clientes, Materiais, Obras e os respetivos registos de Material, Mão de Obra e Pagamentos.


## Executar com Docker
O projeto pode ser executado de forma totalmente isolada usando Docker, sem necessidade de instalar .NET ou PostgreSQL localmente.

### Pré-requisitos
- Docker instalado  
- Docker Compose instalado (ou Docker Desktop)

### Construir e iniciar todos os serviços

Na raiz do projeto (onde está o `docker-compose.yml`):

```bash
docker compose up --build
```

A aplicação ficará disponível em:

```
http://localhost:5225
```

## Estrutura do Projeto

* **Models/** – Classes da aplicação
* **Controllers/** – Lógica de controlo
* **Views/** – Interface da aplicação
* **Data/AppDbContext.cs** – Configuração do Entity Framework
* **docker-compose.yml** – Base de dados PostgreSQL

---
