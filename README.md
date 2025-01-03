# Proyecto web APi en .NET con Conexión a SQL Server

Este proyecto es una aplicacion web Api en .NET que se conecta a una base de datos SQL Server. A continuación adjunto los pasos para ejecutarla

## Requisitos previos

Asegúrate de cumplir con los siguientes requisitos antes de ejecutar el proyecto:

1. **Herramientas necesarias:**
   - .NET SDK (versión 8.0).
   - SQL Server.
   - Visual Studio o cualquier editor de texto con soporte para .NET.

2. **Base de datos:**
   - Se adjunta al correo script de base de datos.

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
   - Abre el archivo `BankSphereApi/appsettings.Development.json`.
   - Actualiza el valor de `SqlServerSettings.ConnectionStrings.SqlServer` con los datos de tu SQL Server local. Ejemplo:
     ```json
     "SqlServerSettings": {
        "ConnectionStrings": {
            "SqlServer": Server=(localdb)\\MSSQLLocalDB;Database=MI_BASE_DE_DATOS;Trusted_Connection=True;
        }
     ```

4. **Crear la base de datos:**
   - Usa el script SQL proporcionado para crear la base de datos y poblarla con los datos iniciales:
     ejecuta el archivo proporcionado en SQL Server Management Studio para crear la base de datos del proyecto.

## Ejecutar el proyecto

1. **Compilar y ejecutar la aplicación:**
   ejecuta el proyecto webApi 

2. **Acceder a la aplicación:**
   - Para esta API, utiliza herramientas como Postman o tu navegador para acceder a la ruta de Swagger https://localhost:7295/swagger/index.html.
