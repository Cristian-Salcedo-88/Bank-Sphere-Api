# Proyecto Básico en .NET con Conexión a SQL Server

Este proyecto es una aplicación básica en .NET que se conecta a una base de datos SQL Server. Incluye instrucciones detalladas para configurarlo y ejecutarlo en otro equipo.

## Requisitos previos

Asegúrate de cumplir con los siguientes requisitos antes de ejecutar el proyecto:

1. **Herramientas necesarias:**
   - .NET SDK (versión 6.0 o superior).
   - SQL Server (local o remoto).
   - Visual Studio o cualquier editor de texto con soporte para .NET.

2. **Base de datos:**
   - Un archivo de script SQL (por ejemplo, `database.sql`) que contiene la estructura y los datos iniciales de la base de datos.

## Configuración del proyecto

1. **Clonar el repositorio:**
   ```bash
   git clone git@github.com:Cristian-Salcedo-88/Bank-Sphere-Api.git
   cd Bank-Sphere-Api
   ```

2. **Restaurar las dependencias del proyecto:**
   ```bash
   dotnet restore
   ```

3. **Configurar la cadena de conexión:**
   - Abre el archivo `appsettings.json`.
   - Actualiza el valor de `ConnectionStrings.DefaultConnection` con los datos de tu SQL Server local. Ejemplo:
     ```json
     "ConnectionStrings": {
         "SqlServer": "Server=(localdb)\\MSSQLLocalDB;Database=MI_BASE_DE_DATOS;Trusted_Connection=True;"
     }
     ```

4. **Crear la base de datos:**
   - Usa el script SQL proporcionado para crear la base de datos y poblarla con los datos iniciales:
     ```bash
     sqlcmd -S (localdb)\\MSSQLLocalDB -i database.sql
     ```
     (Si no tienes `sqlcmd` instalado, puedes ejecutar el script directamente desde una herramienta como SQL Server Management Studio o Azure Data Studio).

## Ejecutar el proyecto

1. **Compilar y ejecutar la aplicación:**
   ```bash
   dotnet run
   ```

2. **Acceder a la aplicación:**
   - Para esta API, utiliza herramientas como Postman o tu navegador para acceder a la ruta de SWAGGER https://localhost:7295/swagger/index.html.
