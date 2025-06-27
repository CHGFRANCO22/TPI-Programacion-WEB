# Proyecto TPI - Sistema de Registro de Usuarios (ASP.NET Core MVC + EF Core)

Este proyecto es una aplicación web construida con **ASP.NET Core MVC** y **Entity Framework Core**, que permite el registro y gestión de usuarios con base de datos local.

---

## 🚀 Tecnologías utilizadas

- ASP.NET Core MVC
- Entity Framework Core
- SQL Server LocalDB
- Visual Studio 2022
- .NET 9.0 (modificá si usás otro)

---

## ⚙️ Requisitos

Antes de clonar el repositorio, asegurate de tener instalado:

- ✅ [.NET SDK 9.0 o superior](https://dotnet.microsoft.com/download)
- ✅ [Visual Studio 2022](https://visualstudio.microsoft.com/) con cargas de trabajo de desarrollo web y .NET.
- ✅ [SQL Server LocalDB](https://docs.microsoft.com/sql/database-engine/configure-windows/sql-server-express-localdb) (viene con Visual Studio)
- ✅ [Entity Framework CLI](https://learn.microsoft.com/ef/core/cli/dotnet)  
  Instalalo si no lo tenés:

  ```bash
  dotnet tool install --global dotnet-ef
  Clonar el repositorio:
  git clone https://github.com/usuario/proyecto.git
cd proyecto/mvc-app

(o si no con visual 2022 git)

Verificar la cadena de conexión en appsettings.json:
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=TPI_DB;Trusted_Connection=True;"
}

3.Aplicar las migraciones y crear la base de datos

Solo la primera vez o si cambiás el modelo de datos:

dotnet ef database update

4. Ejecutar el proyecto:
bash
dotnet run

5. Abrí el navegador en https://localhost:xxxx (la consola te indicará el puerto).



 Pruebas básicas
Podés probar la API o la vista MVC para registrar un usuario. Si usás Postman, enviá un POST a:
POST https://localhost:xxxx/api/auth/register
Con el siguiente JSON:
json
{
  "nombreUsuario": "usuario1",
  "email": "usuario1@email.com",
  "password": "123456"
}

mvc-app/
│
├── Controllers/
├── Models/
├── Services/
├── Data/             # DbContext y configuración EF
├── Migrations/       # EF Core migrations
├── Views/            # Si usás Razor Pages
├── wwwroot/
├── appsettings.json  # Cadena de conexión
└── Program.cs
