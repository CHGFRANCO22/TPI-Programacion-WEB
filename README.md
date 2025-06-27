# Proyecto TPI - Sistema de Registro de Usuarios (ASP.NET Core MVC + EF Core)

Este proyecto es una aplicación web construida con **ASP.NET Core MVC** y **Entity Framework Core**, que permite el registro y gestión de usuarios con base de datos local.

---

## 🚀 Tecnologías utilizadas

- ASP.NET Core MVC
- Entity Framework Core
- SQL Server LocalDB
- Visual Studio 2022
- .NET 9.0 (modificá si usás otro)


## ⚙️ Requisitos

Antes de clonar el repositorio, asegurate de tener instalado:

- ✅ [.NET SDK 9.0 o superior](https://dotnet.microsoft.com/download)
- ✅ [Visual Studio 2022](https://visualstudio.microsoft.com/) con cargas de trabajo de desarrollo web y .NET.
- ✅ [SQL Server LocalDB](https://docs.microsoft.com/sql/database-engine/configure-windows/sql-server-express-localdb) (viene con Visual Studio)
- ✅ [Entity Framework CLI](https://learn.microsoft.com/ef/core/cli/dotnet)  
- ✅ [Postman](https://www.postman.com/) o similar para probar la API (opcional)
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

Restaurar y compilar:
bash:
dotnet restore
dotnet build

4. Aplicar migraciones para que se cree la base de datos automáticamente:
dotnet ef database update --context AppDbContext


4. Ejecutar la aplicacion:
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


## Notas adicionales

- La base de datos se crea automáticamente con las migraciones la primera vez que corras `dotnet ef database update`.  
- Si cambiás los modelos, recordá crear nuevas migraciones con `dotnet ef migrations add NombreMigracion` y aplicar con `dotnet ef database update`.  
- El proyecto está configurado para usar SQL Server LocalDB, que viene con Visual Studio. Si querés usar otro servidor SQL, actualizá la cadena de conexión en `appsettings.json`.  
- Para problemas comunes con la base de datos o conexión, verificá que LocalDB esté instalado y corriendo con `sqllocaldb info` en consola.