# ClubLecturaAPI — Gestor de Club de Lectura

API REST para la gestión de un club de lectura: organización de libros, miembros, reuniones y comentarios. Permite administrar las lecturas, la asistencia y las valoraciones del club.

Pasos
1. Clonar el repositorio:
   git clone https://github.com/Antoniunimi/ClubLecturaAPI.git
   cd ClubLecturaAPI/ClubLecturaAPI

2. Aplicar las migraciones para crear la base de datos:

   dotnet ef database update


3. Ejecutar la API:

   dotnet run


4. Abrir la documentación de Swagger en el navegador (la URL aparece en la consola, por ejemplo):

   https://localhost:7202/swagger


## Cadena de conexión

Se configura en `ClubLecturaAPI/appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=ClubLecturaDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True"
}
```

