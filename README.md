# Proyecto web API en .NET 8

Este proyecto es una aplicación web API desarrollada en .NET 8. A continuación, se detallan los pasos necesarios para ejecutarla.

## Requisitos previos

Asegúrate de cumplir con los siguientes requisitos antes de ejecutar el proyecto:

1. **Herramientas necesarias:**
   - .NET SDK (versión 8.0).
   - SQL Server.
   - Visual Studio o cualquier editor de texto con soporte para .NET.

2. **Base de datos:**
   - Se adjunta un script de base de datos para su revisión, ya que la base de datos está desplegada en un servidor gratuito en la nube.

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
   - La cadena de conexión al servidor gratuito en la nube ya está configurada en el proyecto.
   - En caso de necesitar realizar una configuración local, sigue estos pasos:
     - Abre el archivo `BankSphereApi/appsettings.Development.json`.
     - Actualiza el valor de `SqlServerSettings.ConnectionStrings.SqlServer` con los datos de tu SQL Server local. Ejemplo:
       ```json
       "SqlServerSettings": {
         "ConnectionStrings": {
           "SqlServer": "Server=(localdb)\\MSSQLLocalDB;Database=MI_BASE_DE_DATOS;Trusted_Connection=True;"
         }
       }
       ```

4. **Crear la base de datos (opcional para configuración local):**
   - Usa el script SQL proporcionado para crear la base de datos:
     - Ejecuta el archivo en SQL Server Management Studio para generar la base de datos necesaria para el proyecto.

## Ejecutar el proyecto

1. **Compilar y ejecutar la aplicación:**
   - ejecuta el proyecto de forma local.
     
2. **Acceder a la aplicación:**
   - Para esta API, utiliza herramientas como Postman o tu navegador para acceder a la ruta de Swagger https://localhost:7295/swagger/index.html.
