# Gestão de Obras

Aplicação Web desenvolvida em ASP.NET Core MVC com Entity Framework Core e PostgreSQL.
O projeto permite gerir Clientes, Materiais, Obras e os respetivos registos de Material, Mão de Obra e Pagamentos.

---

## 1. Requisitos

* .NET 7 ou superior
* PostgreSQL 15+
* pgAdmin (opcional)
* Docker (opcional)

---

## 2. Base de Dados (sem Docker)

Criar a base de dados:

```sql
CREATE DATABASE gestaoobras;
```

Se estiveres a usar o ficheiro `.sql` incluído, importa-o usando:

```bash
psql -U postgres -d gestaoobras -f backup_gestaoobras.sql
```

---

## 3. Executar Base de Dados via Docker

Na raiz do projeto:

```bash
docker compose up -d
```

---

## 4. Executar Projeto

Dentro da pasta principal do projeto:

```bash
dotnet restore
dotnet build
dotnet run
```

A aplicação ficará disponível em:

```
http://localhost:5225
```

---

## 5. Funcionalidades

* Gestão de Clientes (CRUD)
* Gestão de Materiais (CRUD)
* Gestão de Obras (CRUD)
* Registo de Material utilizado numa obra
* Registo de Mão de Obra
* Registo de Pagamentos
* Movimentos de Stock (menu dedicado)

---

## 6. Estrutura do Projeto

* **Models/** – Classes da aplicação
* **Controllers/** – Lógica de controlo
* **Views/** – Interface da aplicação
* **Data/AppDbContext.cs** – Configuração do Entity Framework
* **docker-compose.yml** – Base de dados PostgreSQL

---
