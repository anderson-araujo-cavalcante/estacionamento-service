# estacionamento-service

> Repository for products domain.
> ASP.NET Core application and SQL Server with Docker

## Current Entities

|Entity|Description|
|------|-----------|
|PaymentMethod|Available payment methods|
|Garage|Information on amounts charged by each establishment.|
|Passage|Stores data on the period of parking use|

## API Reference

- ASP.NET Core Web API (.Net6)
- ORM Entity Framework Core 7.0.14

## Database 📂

- Currently this API uses SQL SERVER as a database. 

## Local Usage

Prerequisites
- .NET 6 SDK (or newer)
- A .NET code editor or IDE (e.g. VS Code with the C# plugin, Visual Studio, or JetBrains Rider)
- Docker Engine. You can install the engine using Docker Desktop (Windows, macOS, and Linux), Colima (macOS and Linux), or manually on any OS.
- Some experience with ASP.NET Core MVC or Web API and EF is recommended, but not required.


Navigate to the project root folder and run ```docker-compose up -d```

![image](https://github.com/anderson-araujo-cavalcante/estacionamento-service/assets/133878123/b128f5c0-4841-42b6-9d59-a044e8793bf9)


Images will be created and started

![image](https://github.com/anderson-araujo-cavalcante/estacionamento-service/assets/133878123/62cc862e-3071-492c-b649-06cfdead298d)

Open browser and access url ```http://localhost:8000/swagger/index.html```

![image](https://github.com/anderson-araujo-cavalcante/estacionamento-service/assets/133878123/d7f6db49-f714-4cc0-aa64-9c3783eb9081)

Optional
Create dados
Import colletions in postman: [Uploading Estapar.postman_collection.json…]()

Run postman routes create seed data:
1. add-payments-methods-range
2. add-garage-range
3. add-passage-range

Validate GET routes
1. lista-carros
2. fechamento
3. tempo-medio

## In Progress

- Add Tests
- Add FluentValidation
- Add authentication
- Add Authorize
- Add Cache (Blob Storage)
  
