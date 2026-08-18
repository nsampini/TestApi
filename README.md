# TestApi

API ASP.NET Core minima para pruebas.

## Ejecutar localmente

```powershell
dotnet restore
dotnet run
```

Endpoints iniciales:

- `GET /api/health`
- `GET /api/products`

Por defecto corre en `http://localhost:5190`.

## Docker

```powershell
docker build -t testapi:local .
docker run --rm -p 5190:8080 testapi:local
```
