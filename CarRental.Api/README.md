# CarRental API REST

## Descripción

CarRental API es un sistema desarrollado para la gestión de alquiler de vehículos mediante una arquitectura REST, utilizando ASP.NET Core, Entity Framework Core y SQL Server.

El proyecto permite gestionar automóviles y establece las relaciones entre usuarios, vehículos y alquileres mediante una base de datos relacional.

## Tecnologías utilizadas

- C#
- .NET 11
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- SQL Server Management Studio
- Visual Studio Code
- Git y GitHub

## Funcionalidades implementadas

- Registro de automóviles.
- Listado de automóviles.
- Consulta de automóviles por ID.
- Actualización de automóviles.
- Eliminación de automóviles.
- Validación de antigüedad de vehículos.
- Conexión con SQL Server.
- Migraciones mediante Entity Framework Core.
- Transferencia de datos mediante DTO.

## Modelos de datos

- Auto
- Usuario
- Alquiler

## Endpoints disponibles

| Método | Ruta | Descripción |
|--------|------|-------------|
| GET | /api/autos | Listar automóviles |
| GET | /api/autos/{id} | Buscar automóvil |
| POST | /api/autos | Registrar automóvil |
| PUT | /api/autos/{id} | Actualizar automóvil |
| DELETE | /api/autos/{id} | Eliminar automóvil |

## Estructura del proyecto

```text
CarRentalApi1/
├── CarRental.Api/
│   ├── Controllers/
│   ├── Data/
│   ├── Dto/
│   ├── Migrations/
│   ├── Models/
│   ├── Properties/
│   ├── appsettings.json
│   ├── CarRental.Api.http
│   └── Program.cs
├── .gitignore
├── README.md
└── CarRentalApi1.sln
```

## Requisitos

- .NET SDK 11.
- SQL Server.
- Visual Studio Code o Visual Studio.
- Herramienta dotnet-ef compatible con Entity Framework Core.

## Instalación y ejecución

1. Clonar el repositorio.
2. Ingresar a la carpeta CarRental.Api.
3. Configurar la cadena de conexión en appsettings.json.
4. Restaurar las dependencias:

```bash
dotnet restore
```

5. Aplicar las migraciones:

```bash
dotnet ef database update
```

6. Ejecutar la aplicación:

```bash
dotnet run
```

## Estado del proyecto

En desarrollo.

Actualmente se encuentra implementado el controlador CRUD de automóviles y la estructura de la base de datos. Los módulos de gestión de usuarios y alquileres se encuentran pendientes de implementación.

## Información académica

- Institución: SENATI
- Carrera: Desarrollo de Software
- Semestre: V
- Año: 2026

Proyecto desarrollado con fines académicos.