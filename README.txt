Roshan - Starter Accounts Management (Angular + .NET)

Folders:
- backend/RoshanAPI : .NET Web API (Program.cs, Controllers, Models)
- frontend : Angular skeleton with Urdu i18n (assets/i18n/ur.json)

Quick start (backend):
1. Open backend/RoshanAPI in Visual Studio or via CLI.
2. Ensure (localdb)\\MSSQLLocalDB is available.
3. From package manager console:
   dotnet add package Microsoft.EntityFrameworkCore.SqlServer
   dotnet add package Microsoft.EntityFrameworkCore.Tools
   dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
   dotnet add package BCrypt.Net-Next
4. Add migrations and update DB:
   dotnet ef migrations add Init
   dotnet ef database update
5. Run:
   dotnet run

Quick start (frontend):
1. cd frontend
2. npm install
3. ng serve

Notes:
- Project name: Roshan
- DB: RoshanDB on (localdb)\\MSSQLLocalDB
- Default language: Urdu (ur-PK), RTL
- Change JWT key in backend/appsettings.json before production.

Additional completed features:
- AutoMapper profile included.
- Seed data (admin user: admin / Admin@123) and sample accounts.
- Full CRUD for Accounts and Transactions with DTOs.
- Frontend: JWT auth service, HTTP interceptor, Accounts & Transactions components and services added (skeleton).
- Urdu i18n present.

Backend run notes:
- Default Kestrel will run on ports assigned by dotnet; use launchSettings or configure to listen on 5000/5001 if needed.

Security:
- Change the JWT key in appsettings.json before production.
