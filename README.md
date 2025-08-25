# TestApp

## Versiones

- **Backend:** .NET 8.0
- **Frontend:** Angular 20.2.0 (Node.js 22.18.0)
- **Base de datos:** SQL Server 2025 (Docker)

## Instrucciones para ejecutar el proyecto localmente

### 1. Clonar el repositorio
   ```bash
   git clone https://github.com/jdrosas/TestApp.git
   cd TestApp
   ```
   
### 2. Crear la base de datos
Asegurarse de tener Docker y Docker Compose instalados, luego ejecutar:
   ```bash
   docker-compose up -d
   ```
Esto levantará SQL Server en un contenedor.
	
### 3. Backend (.NET API)
Ir a la carpeta del backend y restaurar dependencias:
   ```bash
   cd Backend/TestApp
   dotnet restore
   ```
Si aún no se tiene la herramienta de Entity Framework Core, se debe instalar:
   ```bash
   dotnet tool install --global dotnet-ef
   ```
Aplicar migraciones para crear la base de datos
   ```bash
   cd TestApp
   dotnet ef database update
   ```
Lavantar la API:
   ```bash
   dotnet run
   ```
De esta forma estara disponible en:
- **API:** http://localhost:5000
- **Swagger UI:** http://localhost:5000/swagger

### 4. Frontend (Angular)
Ir a la carpeta del frontend e instalar dependencias:
   ```bash
   cd Frontend/TestApp
   npm install
   ```
Ejecutar la aplicación:
   ```bash
   ng serve
   ```
La aplicación estará disponible en:
- **http://localhost:4200**